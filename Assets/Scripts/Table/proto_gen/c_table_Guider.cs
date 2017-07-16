//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Option: missing-value detection (*Specified/ShouldSerialize*/Reset*) enabled
    
// Generated from: c_table_Guider.proto
// Note: requires additional types generated from: common_guider.proto
namespace Table
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Guider")]
 public partial class Guider : global::ProtoBuf.IExtensible
  {
    public Guider() {}
    

    private uint? _id;
    /// <summary>
    /// ID
    /// </summary>
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id?? default(uint); }
      set { _id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool idSpecified
    {
      get { return _id != null; }
      set { if (value == (_id== null)) _id = value ? id : (uint?)null; }
    }
    private bool ShouldSerializeid() { return idSpecified; }
    private void Resetid() { idSpecified = false; }
    

    private uint? _next_id;
    /// <summary>
    /// 下一个引导
    /// </summary>
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"next_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint next_id
    {
      get { return _next_id?? default(uint); }
      set { _next_id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool next_idSpecified
    {
      get { return _next_id != null; }
      set { if (value == (_next_id== null)) _next_id = value ? next_id : (uint?)null; }
    }
    private bool ShouldSerializenext_id() { return next_idSpecified; }
    private void Resetnext_id() { next_idSpecified = false; }
    

    private bool? _is_server;
    /// <summary>
    /// 是否服务器记录做重现
    /// </summary>
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"is_server", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool is_server
    {
      get { return _is_server?? default(bool); }
      set { _is_server = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool is_serverSpecified
    {
      get { return _is_server != null; }
      set { if (value == (_is_server== null)) _is_server = value ? is_server : (bool?)null; }
    }
    private bool ShouldSerializeis_server() { return is_serverSpecified; }
    private void Resetis_server() { is_serverSpecified = false; }
    

    private uint? _guiderUI_id;
    /// <summary>
    /// 第一个UI引导
    /// </summary>
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"guiderUI_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint guiderUI_id
    {
      get { return _guiderUI_id?? default(uint); }
      set { _guiderUI_id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool guiderUI_idSpecified
    {
      get { return _guiderUI_id != null; }
      set { if (value == (_guiderUI_id== null)) _guiderUI_id = value ? guiderUI_id : (uint?)null; }
    }
    private bool ShouldSerializeguiderUI_id() { return guiderUI_idSpecified; }
    private void ResetguiderUI_id() { guiderUI_idSpecified = false; }
    

    private string _ui_camera;
    /// <summary>
    /// UI相机
    /// </summary>
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"ui_camera", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ui_camera
    {
      get { return _ui_camera?? ""; }
      set { _ui_camera = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool ui_cameraSpecified
    {
      get { return _ui_camera != null; }
      set { if (value == (_ui_camera== null)) _ui_camera = value ? ui_camera : (string)null; }
    }
    private bool ShouldSerializeui_camera() { return ui_cameraSpecified; }
    private void Resetui_camera() { ui_cameraSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
 }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Guider_ARRAY")]
  public partial class Guider_ARRAY : global::ProtoBuf.IExtensible
  {
    public Guider_ARRAY() {}
    
    private readonly global::System.Collections.Generic.List<Table.Guider> _rows = new global::System.Collections.Generic.List<Table.Guider>();
    [global::ProtoBuf.ProtoMember(1, Name=@"rows", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.Guider> rows
    {
      get { return _rows; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GuiderUI")]
 public partial class GuiderUI : global::ProtoBuf.IExtensible
  {
    public GuiderUI() {}
    

    private uint? _id;
    /// <summary>
    /// ID
    /// </summary>
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id?? default(uint); }
      set { _id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool idSpecified
    {
      get { return _id != null; }
      set { if (value == (_id== null)) _id = value ? id : (uint?)null; }
    }
    private bool ShouldSerializeid() { return idSpecified; }
    private void Resetid() { idSpecified = false; }
    

    private uint? _next_id;
    /// <summary>
    /// 下一个引导
    /// </summary>
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"next_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint next_id
    {
      get { return _next_id?? default(uint); }
      set { _next_id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool next_idSpecified
    {
      get { return _next_id != null; }
      set { if (value == (_next_id== null)) _next_id = value ? next_id : (uint?)null; }
    }
    private bool ShouldSerializenext_id() { return next_idSpecified; }
    private void Resetnext_id() { next_idSpecified = false; }
    

    private bool? _statistical;
    /// <summary>
    /// 做统计
    /// </summary>
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"statistical", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool statistical
    {
      get { return _statistical?? default(bool); }
      set { _statistical = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool statisticalSpecified
    {
      get { return _statistical != null; }
      set { if (value == (_statistical== null)) _statistical = value ? statistical : (bool?)null; }
    }
    private bool ShouldSerializestatistical() { return statisticalSpecified; }
    private void Resetstatistical() { statisticalSpecified = false; }
    

    private string _node_path;
    /// <summary>
    /// 路径
    /// </summary>
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"node_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string node_path
    {
      get { return _node_path?? ""; }
      set { _node_path = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool node_pathSpecified
    {
      get { return _node_path != null; }
      set { if (value == (_node_path== null)) _node_path = value ? node_path : (string)null; }
    }
    private bool ShouldSerializenode_path() { return node_pathSpecified; }
    private void Resetnode_path() { node_pathSpecified = false; }
    

    private Common.GuiderAnimType? _ui_anim_type;
    /// <summary>
    /// 提示动画类型
    /// </summary>
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"ui_anim_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Common.GuiderAnimType ui_anim_type
    {
      get { return _ui_anim_type?? Common.GuiderAnimType.ANIM_TYPE_NONE; }
      set { _ui_anim_type = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool ui_anim_typeSpecified
    {
      get { return _ui_anim_type != null; }
      set { if (value == (_ui_anim_type== null)) _ui_anim_type = value ? ui_anim_type : (Common.GuiderAnimType?)null; }
    }
    private bool ShouldSerializeui_anim_type() { return ui_anim_typeSpecified; }
    private void Resetui_anim_type() { ui_anim_typeSpecified = false; }
    

    private string _attach_ui;
    /// <summary>
    /// 附加UI动画
    /// </summary>
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"attach_ui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string attach_ui
    {
      get { return _attach_ui?? ""; }
      set { _attach_ui = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool attach_uiSpecified
    {
      get { return _attach_ui != null; }
      set { if (value == (_attach_ui== null)) _attach_ui = value ? attach_ui : (string)null; }
    }
    private bool ShouldSerializeattach_ui() { return attach_uiSpecified; }
    private void Resetattach_ui() { attach_uiSpecified = false; }
    

    private bool? _send_finish;
    /// <summary>
    /// 做完这步可认为结束
    /// </summary>
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"send_finish", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool send_finish
    {
      get { return _send_finish?? default(bool); }
      set { _send_finish = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool send_finishSpecified
    {
      get { return _send_finish != null; }
      set { if (value == (_send_finish== null)) _send_finish = value ? send_finish : (bool?)null; }
    }
    private bool ShouldSerializesend_finish() { return send_finishSpecified; }
    private void Resetsend_finish() { send_finishSpecified = false; }
    

    private string _ui_camera;
    /// <summary>
    /// UI相机出现变更
    /// </summary>
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"ui_camera", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ui_camera
    {
      get { return _ui_camera?? ""; }
      set { _ui_camera = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool ui_cameraSpecified
    {
      get { return _ui_camera != null; }
      set { if (value == (_ui_camera== null)) _ui_camera = value ? ui_camera : (string)null; }
    }
    private bool ShouldSerializeui_camera() { return ui_cameraSpecified; }
    private void Resetui_camera() { ui_cameraSpecified = false; }
    

    private Common.GuiderTriggerType? _begin_type;
    /// <summary>
    /// 开始方式
    /// </summary>
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"begin_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Common.GuiderTriggerType begin_type
    {
      get { return _begin_type?? Common.GuiderTriggerType.TRIGGER_INVALID; }
      set { _begin_type = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool begin_typeSpecified
    {
      get { return _begin_type != null; }
      set { if (value == (_begin_type== null)) _begin_type = value ? begin_type : (Common.GuiderTriggerType?)null; }
    }
    private bool ShouldSerializebegin_type() { return begin_typeSpecified; }
    private void Resetbegin_type() { begin_typeSpecified = false; }
    

    private Common.GuiderTriggerType? _end_type;
    /// <summary>
    /// 结束方式
    /// </summary>
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"end_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Common.GuiderTriggerType end_type
    {
      get { return _end_type?? Common.GuiderTriggerType.TRIGGER_INVALID; }
      set { _end_type = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool end_typeSpecified
    {
      get { return _end_type != null; }
      set { if (value == (_end_type== null)) _end_type = value ? end_type : (Common.GuiderTriggerType?)null; }
    }
    private bool ShouldSerializeend_type() { return end_typeSpecified; }
    private void Resetend_type() { end_typeSpecified = false; }
    

    private bool? _need_mask;
    /// <summary>
    /// 是否需要遮罩
    /// </summary>
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"need_mask", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool need_mask
    {
      get { return _need_mask?? default(bool); }
      set { _need_mask = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool need_maskSpecified
    {
      get { return _need_mask != null; }
      set { if (value == (_need_mask== null)) _need_mask = value ? need_mask : (bool?)null; }
    }
    private bool ShouldSerializeneed_mask() { return need_maskSpecified; }
    private void Resetneed_mask() { need_maskSpecified = false; }
    

    private Common.Vec3 _tip_pos = null;
    /// <summary>
    /// 提示位置
    /// </summary>
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"tip_pos", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.Vec3 tip_pos
    {
      get { return _tip_pos; }
      set { _tip_pos = value; }
    }

    private string _tip_text;
    /// <summary>
    /// 提示内容
    /// </summary>
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"tip_text", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string tip_text
    {
      get { return _tip_text?? ""; }
      set { _tip_text = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool tip_textSpecified
    {
      get { return _tip_text != null; }
      set { if (value == (_tip_text== null)) _tip_text = value ? tip_text : (string)null; }
    }
    private bool ShouldSerializetip_text() { return tip_textSpecified; }
    private void Resettip_text() { tip_textSpecified = false; }
    

    private Common.Vec3 _follow_offset = null;
    /// <summary>
    /// UI动画偏移
    /// </summary>
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"follow_offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.Vec3 follow_offset
    {
      get { return _follow_offset; }
      set { _follow_offset = value; }
    }

    private Common.GuiderFollowType? _follow_type;
    /// <summary>
    /// UI动画刷新频率
    /// </summary>
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"follow_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Common.GuiderFollowType follow_type
    {
      get { return _follow_type?? Common.GuiderFollowType.FOLLOW_ONCE; }
      set { _follow_type = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool follow_typeSpecified
    {
      get { return _follow_type != null; }
      set { if (value == (_follow_type== null)) _follow_type = value ? follow_type : (Common.GuiderFollowType?)null; }
    }
    private bool ShouldSerializefollow_type() { return follow_typeSpecified; }
    private void Resetfollow_type() { follow_typeSpecified = false; }
    

    private bool? _use_replacement;
    /// <summary>
    /// 使用替代物体
    /// </summary>
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"use_replacement", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool use_replacement
    {
      get { return _use_replacement?? default(bool); }
      set { _use_replacement = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool use_replacementSpecified
    {
      get { return _use_replacement != null; }
      set { if (value == (_use_replacement== null)) _use_replacement = value ? use_replacement : (bool?)null; }
    }
    private bool ShouldSerializeuse_replacement() { return use_replacementSpecified; }
    private void Resetuse_replacement() { use_replacementSpecified = false; }
    

    private Common.Vec3 _replacement_size = null;
    /// <summary>
    /// 替代物大小
    /// </summary>
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"replacement_size", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.Vec3 replacement_size
    {
      get { return _replacement_size; }
      set { _replacement_size = value; }
    }

    private Common.Vec3 _replacement_offset = null;
    /// <summary>
    /// 替代物偏移
    /// </summary>
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"replacement_offset", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.Vec3 replacement_offset
    {
      get { return _replacement_offset; }
      set { _replacement_offset = value; }
    }

    private Common.GuiderEvent _begin_event = null;
    /// <summary>
    /// 开始事件
    /// </summary>
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"begin_event", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.GuiderEvent begin_event
    {
      get { return _begin_event; }
      set { _begin_event = value; }
    }

    private Common.GuiderEvent _end_event = null;
    /// <summary>
    /// 结束事件
    /// </summary>
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"end_event", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Common.GuiderEvent end_event
    {
      get { return _end_event; }
      set { _end_event = value; }
    }

    private bool? _is_3d;
    /// <summary>
    /// 是否是3D
    /// </summary>
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"is_3d", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool is_3d
    {
      get { return _is_3d?? default(bool); }
      set { _is_3d = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool is_3dSpecified
    {
      get { return _is_3d != null; }
      set { if (value == (_is_3d== null)) _is_3d = value ? is_3d : (bool?)null; }
    }
    private bool ShouldSerializeis_3d() { return is_3dSpecified; }
    private void Resetis_3d() { is_3dSpecified = false; }
    

    private string _camera_3d;
    /// <summary>
    /// 3D相机
    /// </summary>
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"camera_3d", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string camera_3d
    {
      get { return _camera_3d?? ""; }
      set { _camera_3d = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool camera_3dSpecified
    {
      get { return _camera_3d != null; }
      set { if (value == (_camera_3d== null)) _camera_3d = value ? camera_3d : (string)null; }
    }
    private bool ShouldSerializecamera_3d() { return camera_3dSpecified; }
    private void Resetcamera_3d() { camera_3dSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
 }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GuiderUI_ARRAY")]
  public partial class GuiderUI_ARRAY : global::ProtoBuf.IExtensible
  {
    public GuiderUI_ARRAY() {}
    
    private readonly global::System.Collections.Generic.List<Table.GuiderUI> _rows = new global::System.Collections.Generic.List<Table.GuiderUI>();
    [global::ProtoBuf.ProtoMember(1, Name=@"rows", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.GuiderUI> rows
    {
      get { return _rows; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GuiderMsg")]
 public partial class GuiderMsg : global::ProtoBuf.IExtensible
  {
    public GuiderMsg() {}
    

    private uint? _id;
    /// <summary>
    /// ID
    /// </summary>
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint id
    {
      get { return _id?? default(uint); }
      set { _id = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool idSpecified
    {
      get { return _id != null; }
      set { if (value == (_id== null)) _id = value ? id : (uint?)null; }
    }
    private bool ShouldSerializeid() { return idSpecified; }
    private void Resetid() { idSpecified = false; }
    
    private readonly global::System.Collections.Generic.List<uint> _guider_id_list = new global::System.Collections.Generic.List<uint>();
    [global::ProtoBuf.ProtoMember(2, Name=@"guider_id_list", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<uint> guider_id_list
    {
      get { return _guider_id_list; }
    }
  

    private Common.GuiderMsgCmd? _cmd;
    /// <summary>
    /// 指令
    /// </summary>
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"cmd", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Common.GuiderMsgCmd cmd
    {
      get { return _cmd?? Common.GuiderMsgCmd.MSG_CMD_INVALID; }
      set { _cmd = value; }
    }
    //Here has been deleted XmlIgnore
    [global::System.ComponentModel.Browsable(false)]
    public bool cmdSpecified
    {
      get { return _cmd != null; }
      set { if (value == (_cmd== null)) _cmd = value ? cmd : (Common.GuiderMsgCmd?)null; }
    }
    private bool ShouldSerializecmd() { return cmdSpecified; }
    private void Resetcmd() { cmdSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
 }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GuiderMsg_ARRAY")]
  public partial class GuiderMsg_ARRAY : global::ProtoBuf.IExtensible
  {
    public GuiderMsg_ARRAY() {}
    
    private readonly global::System.Collections.Generic.List<Table.GuiderMsg> _rows = new global::System.Collections.Generic.List<Table.GuiderMsg>();
    [global::ProtoBuf.ProtoMember(1, Name=@"rows", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.GuiderMsg> rows
    {
      get { return _rows; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}