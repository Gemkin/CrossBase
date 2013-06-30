using System;
using System.IO;

namespace CrossBase.Serialization
{
    public interface IObjectSerializer : IDisposable
    {
        Stream Serialize(object source);
        T Deserialize<T>(Stream stream);
        bool IsSerializable<T>(T source);
    }
}