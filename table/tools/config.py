#!/usr/bin/python
# encoding=utf-8

import os
import subprocess

class ExeRsp(object):
    def __init__(self):
        self.returncode = 0
        self.stderr = ''

class OneDes(object):
    def __init__(self):
        self.name = ''
        self.type = ''
        self.des = ''

class Config(object):
    def __init__(self):
        self.table_path = '../table'
        self.proto_path = '../proto'
        self.enable_add_des = True # 是否添加注释

        self.client_table_prefix = 'c_table_'
        self.server_table_prefix = 's_table_'
        self.common_prefix = 'common_'
        self.command_prefix = 'command_'

        self.client_table_package = 'Table'
        self.server_table_package = 'table'
        
        self.table_cs_path = '../output/table_cs' # 表格CS文件存储相对路径
        self.table_data_path = '../output/table_data' # 表格二进制文件存储相对路径
        self.common_cs_path = '../output/common_cs' # 公共PB的CS文件存储相对路径
        self.command_cs_path = '../output/command_cs' # 协议PB的CS文件存储相对路径
        
        self.unity_table_cs_path = '../../Assets/Scripts/Table/proto_gen' # Unity中表格CS文件存储相对路径
        self.unity_table_data_path = '../../Assets/Resources/Table' # Unity中表格二进制文件存储相对路径
        self.unity_common_cs_path = '../../Assets/Scripts/MSG/Common' # Unity中公共PB的CS文件存储相对路径
        self.unity_command_cs_path = '../../Assets/Scripts/MSG/cmd' # Unity中协议PB的CS文件存储相对路径

    @classmethod
    def proto_to_cs(cls, proto_name, cs_path):
        os.system('protogen.exe -i:' + proto_name + ' -o:' + cs_path + ' -p:detectMissing')

    @classmethod
    def generate_proto_py_file(cls, pattern):
        ret = Config.execute_shell_command(['protoc.exe', '-I.', '--python_out=.', '{}.proto'.format(pattern)], 'T')
        return ret

    @classmethod
    def delete_xml(cls, cs_path):
        text = ''
        pattern = '[global::System.Xml.Serialization.XmlIgnore]'
        target = '//Here has been deleted XmlIgnore'
        with open(cs_path, 'r') as f:
            text = f.read()
        if text.count(pattern) > 0:
            with open(cs_path,'w') as f:
                text = text.replace(pattern, target)
                f.write(text)

    @classmethod
    def add_des_from_proto_to_cs(cls, proto_path, cs_path):
        proto_text = ''
        with open(proto_path, 'r') as f:
            proto_text = f.readlines()
        Config.split_proto(proto_text, cs_path)

    @classmethod
    def split_proto(cls, proto_text, cs_path):
        if len(proto_text) <= 0:
            return
        tmp_text = []
        is_in_finding = False
        cnt = 0
        finding_type = 0
        idx = 0
        
        for line in proto_text:
            idx = idx + 1
            if line.startswith('enum '):
                is_in_finding = True
                finding_type = 0
                tmp_text.append(line)
                if line.find('{') != -1:
                    cnt = 1
                break
            elif line.startswith('message '):
                is_in_finding = True
                finding_type = 1
                tmp_text.append(line)
                if line.find('{') != -1:
                    cnt = 1
                break

        if is_in_finding == False:
            return
        proto_text[0 : idx] = []
        idx = 0
        if len(proto_text) <= 0:
            return

        if cnt == 0:
            for line in proto_text:
                idx = idx + 1
                tmp_text.append(line)
                if line.find('{') != -1:
                    cnt = 1
                break
            
            if cnt != 1:
                return

            proto_text[0 : idx] = []
            idx = 0
            if len(proto_text) <= 0:
                return

        for line in proto_text:
            idx = idx + 1
            tmp_text.append(line)
            if line.find('{') != -1:
                cnt = cnt + 1
                if cnt == 0:
                    break
            elif line.find('}') != -1:
                cnt = cnt - 1
                if cnt == 0:
                    break

        if cnt != 0:
            return
        proto_text[0 : idx] = []
        idx = 0

        Config.do_one_split_proto(tmp_text, cs_path, finding_type)

        if len(proto_text) <= 0:
            return
        Config.split_proto(proto_text, cs_path)

    @classmethod
    def do_one_split_proto(cls, proto_text, cs_path, p_type):
        des_list = []
        for line in proto_text:
            if line.find('//') != -1:
                oneDes = OneDes()
                oneDes.des = line.split('//', 1)[1].strip()
                first = line.split('//', 1)[0].strip()
                first = first.replace('\t', ' ')
                while first.find('  ') != -1:
                    first = first.replace('  ', ' ')
                if p_type == 0:
                    oneDes.type = first.split('=', 1)[0].strip()
                else:
                    first = first.split('=', 1)[0].strip()
                    s_list = first.split(' ')
                    oneDes.type = s_list[1].strip()
                    oneDes.name = s_list[2].strip()
                des_list.append(oneDes)

        if len(des_list) <= 0:
            return
        
        cs_text = ''
        name_str = ''
        with open(cs_path, 'r') as f:
            cs_text = f.readlines()
        if p_type == 0:
            name_str = 'public {}'.format(proto_text[0].strip())
        else:
            name_str_t = proto_text[0].strip().split(' ', 1)[1].strip()
            name_str = 'public partial class {} : global::ProtoBuf.IExtensible'.format(name_str_t)

        idx_s = -1
        cnt = -1
        for line in cs_text:
            idx_s = idx_s + 1
            if line.find(name_str) != -1:
                if line.find('{') != -1:
                    cnt = 1
                else:
                    cnt = 0
                break

        if cnt == -1:
            return

        idx_t = -1
        first = True
        if cnt == 1:
            first = False
        for line in cs_text:
            idx_t = idx_t + 1
            if idx_t <= idx_s:
                continue

            if line.find('{') != -1:
                cnt = cnt + 1
                first = False
            if first == False and line.find('}') != -1: #生成的文件，可能左右括号在一行
                cnt = cnt - 1

            if cnt == 0 and first == False:
                break
            cs_text[idx_t] = Config.try_add_des(des_list, p_type, line)

        with open(cs_path, 'w') as f:
            f.writelines(cs_text)
            
    @classmethod
    def try_add_des(cls, des_list, p_type, val):
        if len(val.strip()) <= 0:
            return val
        
        if p_type == 0:
            for oneDes in des_list:
                if val.find('[global::ProtoBuf.ProtoEnum(Name=@"{}", Value='.format(oneDes.type)) != -1:
                    des_str = '      /// <summary>\n      /// {}\n      /// </summary>\n'.format(oneDes.des)
                    return des_str + val
        else:
            for oneDes in des_list:
                n_key = '    /// <summary>\n    /// {}\n    /// </summary>\n'.format(oneDes.des)
                f_key = 'private {} _{} = null;'.format(oneDes.type, oneDes.name) #结构
                if val.find(f_key) != -1:
                    return val + n_key
                else:
                    f_key = 'private {}? _{};'.format(oneDes.type, oneDes.name) #大部分
                    if val.find(f_key) != -1:
                        return val + n_key
                    else:
                        f_key = 'private {} _{};'.format(oneDes.type, oneDes.name) #sring
                        if val.find(f_key) != -1:    
                            return val + n_key
                        else:
                            # 枚举再判一次，忽略包名，这里有极小的概率出乱子，两个枚举同名不同包在同一个类使用的时候
                            f_key = '.{}? _{};'.format(oneDes.type, oneDes.name)
                            if val.find(f_key) != -1:    
                                return val + n_key
        return val

    @classmethod
    def execute_shell_command(cls, args, wait = 'T'):
        ret = ExeRsp()
        p = subprocess.Popen(args, stderr=subprocess.PIPE)
        if wait == 'T':
            ret.returncode = p.wait()
            ret.stderr = p.stderr.read()
            return ret
        else:
            rsp.returncode = 0
            return ret
