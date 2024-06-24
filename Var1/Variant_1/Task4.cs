using System;
using System.IO;
using System.Text.Json;

namespace Variant_1
{
    public class Task4
    {
        interface ICreator
        {
            void CreateFolder(string path, object file);
            void CreateFile(string path, object file);
        }

        public abstract class AbstractSerializer : ICreator
        {
            public abstract void Write<T>(T obj, string path);
            public abstract T Read<T>(string path);

            public void CreateFolder(string path, object file)
            {
                if (file is string)
                {
                    string folderName = (string)file;
                    string folderPath = Path.Combine(path, folderName);
                    Directory.CreateDirectory(folderPath);
                }
                else if (file is string[])
                {
                    string[] folderNames = (string[])file;
                    foreach (string folderName in folderNames)
                    {
                        CreateFolder(path, folderName);
                    }
                }
            }

            public void CreateFile(string path, object file)
            {
                if (file is string)
                {
                    string fileName = (string)file;
                    File.Create(Path.Combine(path, fileName)).Close();
                }
                else if (file is string[])
                {
                    string[] fileNames = (string[])file;
                    foreach (var fileName in fileNames)
                    {
                        File.Create(Path.Combine(path, fileName)).Close();
                    }
                }
            }
        }

        public class SearcherSerialize : AbstractSerializer
        {
            public SearcherSerialize() { }

            public override void Write<T>(T obj, string path)
            {
                string json = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, json);
            }

            public override T Read<T>(string path)
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json);
            }

        }
    }
}