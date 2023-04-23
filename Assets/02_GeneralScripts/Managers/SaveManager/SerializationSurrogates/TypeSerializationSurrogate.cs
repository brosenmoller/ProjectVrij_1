using System.Runtime.Serialization;
using System;

public class TypeSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Type type = (Type)obj;
        info.AddValue("name", type.FullName);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Type type = Type.GetType((string)info.GetValue("name", typeof(string)));
        obj = type;
        return obj;
    }
}