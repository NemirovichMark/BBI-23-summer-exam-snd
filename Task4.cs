using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Variant_2
{
    public class Task4
    {
        private Task3.Grep grep;
        public Task3.Grep Grep { get { return grep; } }

        public interface IDataSerializer
        {
            public void Write<T>(T obj, string filepath);
            public T Read<T>(string filepath);
        }
        public interface ICreator
        {
            public void CreateFolder(string path, string name);
            public void CreateFolder(string path, string[] names);
            public void CreateFile(string path, string name);
            public void CreateFile(string path, string[] names);
        }
        public class DataSerializer : IDataSerializer, ICreator
        {
            public void Write<T>(T obj, string filepath)
            {
                using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }
            public T Read<T>(string filepath)
            {
                string s = File.ReadAllText(filepath);
                return JsonSerializer.Deserialize<T>(s);
            }

            public void CreateFolder(string path, string name)
            {
                Directory.CreateDirectory(Path.Combine(path, name));
            }

            public void CreateFolder(string path, string[] names)
            {
                foreach (string name in names)
                {
                    Directory.CreateDirectory(Path.Combine(path, name));
                }
            }

            public void CreateFile(string path, string name)
            {
                File.Create(Path.Combine(path, name));
            }

            public void CreateFile(string path, string[] names)
            {
                foreach (string name in names)
                {
                    File.Create(Path.Combine(path, name));
                }
            }
        }
    }
}