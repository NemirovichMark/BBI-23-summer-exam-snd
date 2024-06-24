using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
#region Выберите библиотеку(и) для сериализации
using Newtonsoft;
using System.Text.Json;
using System.Text.Json.Serialization;
#endregion
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
                    string fileName = (string)file;

                }
                else if (file is string[])
                {
                    string[] fileNames = (string[])file;
                }
            }
            public void CreateFile(string path, object file)
            {
                if (file is string)
                {
                    string fileName = (string)file;

                }
                else if (file is string[])
                {
                    string[] fileNames = (string[])file;
                }
            }

        }

        public class SearcherSerialize : AbstractSerializer
        {
            public override void Write<T>(T obj, string path)
            {

            }

            public override T Read<T>(string path)
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}