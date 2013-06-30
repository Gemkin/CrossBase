using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CrossBase.Serialization;

namespace CrossBase.Platform.Shared
{
    public class BinarySerializer : IObjectSerializer
    {
        public Stream Serialize(object source)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, source);
            return stream;
        }

        public T Deserialize<T>(Stream stream)
        {
            var formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }

        public bool IsSerializable<T>(T source)
        {
            return typeof (T).IsSerializable;
        }

        public void Dispose()
        {
            
        }
    }
}