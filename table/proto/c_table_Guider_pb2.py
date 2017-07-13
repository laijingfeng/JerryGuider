# Generated by the protocol buffer compiler.  DO NOT EDIT!

from google.protobuf import descriptor
from google.protobuf import message
from google.protobuf import reflection
from google.protobuf import service
from google.protobuf import service_reflection
from google.protobuf import descriptor_pb2



_GUIDER = descriptor.Descriptor(
  name='Guider',
  full_name='Table.Guider',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='id', full_name='Table.Guider.id', index=0,
      number=1, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='next_id', full_name='Table.Guider.next_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='is_server', full_name='Table.Guider.is_server', index=2,
      number=3, type=8, cpp_type=7, label=1,
      default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='guiderUI_id', full_name='Table.Guider.guiderUI_id', index=3,
      number=4, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='ui_camera', full_name='Table.Guider.ui_camera', index=4,
      number=5, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)


_GUIDER_ARRAY = descriptor.Descriptor(
  name='Guider_ARRAY',
  full_name='Table.Guider_ARRAY',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='rows', full_name='Table.Guider_ARRAY.rows', index=0,
      number=1, type=11, cpp_type=10, label=3,
      default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)


_GUIDERUI = descriptor.Descriptor(
  name='GuiderUI',
  full_name='Table.GuiderUI',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='id', full_name='Table.GuiderUI.id', index=0,
      number=1, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='next_id', full_name='Table.GuiderUI.next_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='statistical', full_name='Table.GuiderUI.statistical', index=2,
      number=3, type=8, cpp_type=7, label=1,
      default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='node_path', full_name='Table.GuiderUI.node_path', index=3,
      number=4, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='ui_anim_type', full_name='Table.GuiderUI.ui_anim_type', index=4,
      number=5, type=14, cpp_type=8, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='attach_ui', full_name='Table.GuiderUI.attach_ui', index=5,
      number=6, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='send_finish', full_name='Table.GuiderUI.send_finish', index=6,
      number=7, type=8, cpp_type=7, label=1,
      default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='ui_camera', full_name='Table.GuiderUI.ui_camera', index=7,
      number=8, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='begin_type', full_name='Table.GuiderUI.begin_type', index=8,
      number=9, type=14, cpp_type=8, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='end_type', full_name='Table.GuiderUI.end_type', index=9,
      number=10, type=14, cpp_type=8, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='need_mask', full_name='Table.GuiderUI.need_mask', index=10,
      number=11, type=8, cpp_type=7, label=1,
      default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='tip_pos', full_name='Table.GuiderUI.tip_pos', index=11,
      number=12, type=11, cpp_type=10, label=1,
      default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='tip_text', full_name='Table.GuiderUI.tip_text', index=12,
      number=13, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='follow_offset', full_name='Table.GuiderUI.follow_offset', index=13,
      number=14, type=11, cpp_type=10, label=1,
      default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)


_GUIDERUI_ARRAY = descriptor.Descriptor(
  name='GuiderUI_ARRAY',
  full_name='Table.GuiderUI_ARRAY',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='rows', full_name='Table.GuiderUI_ARRAY.rows', index=0,
      number=1, type=11, cpp_type=10, label=3,
      default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)


_GUIDERMSG = descriptor.Descriptor(
  name='GuiderMsg',
  full_name='Table.GuiderMsg',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='id', full_name='Table.GuiderMsg.id', index=0,
      number=1, type=13, cpp_type=3, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='guider_id_list', full_name='Table.GuiderMsg.guider_id_list', index=1,
      number=2, type=13, cpp_type=3, label=3,
      default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='cmd', full_name='Table.GuiderMsg.cmd', index=2,
      number=3, type=14, cpp_type=8, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)


_GUIDERMSG_ARRAY = descriptor.Descriptor(
  name='GuiderMsg_ARRAY',
  full_name='Table.GuiderMsg_ARRAY',
  filename='c_table_Guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='rows', full_name='Table.GuiderMsg_ARRAY.rows', index=0,
      number=1, type=11, cpp_type=10, label=3,
      default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],  # TODO(robinson): Implement.
  enum_types=[
  ],
  options=None)

import common_guider_pb2

_GUIDER_ARRAY.fields_by_name['rows'].message_type = _GUIDER
_GUIDERUI.fields_by_name['ui_anim_type'].enum_type = common_guider_pb2._GUIDERANIMTYPE
_GUIDERUI.fields_by_name['begin_type'].enum_type = common_guider_pb2._GUIDERTRIGGERTYPE
_GUIDERUI.fields_by_name['end_type'].enum_type = common_guider_pb2._GUIDERTRIGGERTYPE
_GUIDERUI.fields_by_name['tip_pos'].message_type = common_guider_pb2._VEC3
_GUIDERUI.fields_by_name['follow_offset'].message_type = common_guider_pb2._VEC3
_GUIDERUI_ARRAY.fields_by_name['rows'].message_type = _GUIDERUI
_GUIDERMSG.fields_by_name['cmd'].enum_type = common_guider_pb2._GUIDERMSGCMD
_GUIDERMSG_ARRAY.fields_by_name['rows'].message_type = _GUIDERMSG

class Guider(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDER

class Guider_ARRAY(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDER_ARRAY

class GuiderUI(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDERUI

class GuiderUI_ARRAY(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDERUI_ARRAY

class GuiderMsg(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDERMSG

class GuiderMsg_ARRAY(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDERMSG_ARRAY

