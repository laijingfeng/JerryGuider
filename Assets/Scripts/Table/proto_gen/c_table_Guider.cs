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
      get { return _cmd?? Common.GuiderMsgCmd.INVALID; }
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