# Generated by the protocol buffer compiler.  DO NOT EDIT!

from google.protobuf import descriptor
from google.protobuf import message
from google.protobuf import reflection
from google.protobuf import service
from google.protobuf import service_reflection
from google.protobuf import descriptor_pb2
_GUIDERMSGCMD = descriptor.EnumDescriptor(
  name='GuiderMsgCmd',
  full_name='Common.GuiderMsgCmd',
  filename='GuiderMsgCmd',
  values=[
    descriptor.EnumValueDescriptor(
      name='MSG_CMD_INVALID', index=0, number=0,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='MSG_CMD_OPEN', index=1, number=1,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='MSG_CMD_CLOSE', index=2, number=2,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='MSG_CMD_Reopen', index=3, number=3,
      options=None,
      type=None),
  ],
  options=None,
)


_GUIDERTRIGGERTYPE = descriptor.EnumDescriptor(
  name='GuiderTriggerType',
  full_name='Common.GuiderTriggerType',
  filename='GuiderTriggerType',
  values=[
    descriptor.EnumValueDescriptor(
      name='TRIGGER_INVALID', index=0, number=0,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='TRIGGER_AUTO', index=1, number=1,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='TRIGGER_MSG', index=2, number=2,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='TRIGGER_CLICK_MASK', index=3, number=3,
      options=None,
      type=None),
  ],
  options=None,
)


_GUIDERFOLLOWTYPE = descriptor.EnumDescriptor(
  name='GuiderFollowType',
  full_name='Common.GuiderFollowType',
  filename='GuiderFollowType',
  values=[
    descriptor.EnumValueDescriptor(
      name='FOLLOW_ONCE', index=0, number=0,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='FOLLOW_TIME', index=1, number=1,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='FOLLOW_FRAME', index=2, number=2,
      options=None,
      type=None),
  ],
  options=None,
)


_GUIDERANIMTYPE = descriptor.EnumDescriptor(
  name='GuiderAnimType',
  full_name='Common.GuiderAnimType',
  filename='GuiderAnimType',
  values=[
    descriptor.EnumValueDescriptor(
      name='ANIM_TYPE_NONE', index=0, number=0,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='ANIM_TYPE_ATTACH', index=1, number=1,
      options=None,
      type=None),
    descriptor.EnumValueDescriptor(
      name='ANIM_TYPE_CLICK', index=2, number=10,
      options=None,
      type=None),
  ],
  options=None,
)


MSG_CMD_INVALID = 0
MSG_CMD_OPEN = 1
MSG_CMD_CLOSE = 2
MSG_CMD_Reopen = 3
TRIGGER_INVALID = 0
TRIGGER_AUTO = 1
TRIGGER_MSG = 2
TRIGGER_CLICK_MASK = 3
FOLLOW_ONCE = 0
FOLLOW_TIME = 1
FOLLOW_FRAME = 2
ANIM_TYPE_NONE = 0
ANIM_TYPE_ATTACH = 1
ANIM_TYPE_CLICK = 10



_VEC3 = descriptor.Descriptor(
  name='Vec3',
  full_name='Common.Vec3',
  filename='common_guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='x', full_name='Common.Vec3.x', index=0,
      number=1, type=2, cpp_type=6, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='y', full_name='Common.Vec3.y', index=1,
      number=2, type=2, cpp_type=6, label=1,
      default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='z', full_name='Common.Vec3.z', index=2,
      number=3, type=2, cpp_type=6, label=1,
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


_GUIDEREVENT = descriptor.Descriptor(
  name='GuiderEvent',
  full_name='Common.GuiderEvent',
  filename='common_guider.proto',
  containing_type=None,
  fields=[
    descriptor.FieldDescriptor(
      name='name', full_name='Common.GuiderEvent.name', index=0,
      number=1, type=9, cpp_type=9, label=1,
      default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    descriptor.FieldDescriptor(
      name='par', full_name='Common.GuiderEvent.par', index=1,
      number=2, type=9, cpp_type=9, label=1,
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



class Vec3(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _VEC3

class GuiderEvent(message.Message):
  __metaclass__ = reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _GUIDEREVENT

