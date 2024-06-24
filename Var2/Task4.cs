using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static Variant_2.Task3;
#region Выберите библиотеку(и) для сериализации
using Newtonsoft;

#endregion
namespace Variant_2
{
    public class Task4
    {
        public interface IDataSerializer
        {
            void Write(object obj, string path);
            T Read<T>(string path);
        }

        public interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolder(string path, string[] folderNames);
            void CreateFile(string path, string[] fileNames);
        }

        public class DataSerializer : IDataSerializer, ICreator
        {
            private Grep G;

            public Grep Grep => G;

            public DataSerializer()
            {
                G = new Grep(string.Empty);
            }

            public DataSerializer(Grep grep)
            {
                G = grep;
            }

            public void Write(object obj, string path)
            {
                string json = JsonConvert.SerializeObject(obj);
                File.WriteAllText(path, json);
            }

            public T Read<T>(string path)
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }

            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Dispose();
            }

            public void CreateFolder(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFile(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }
        }
    }
}