using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
// using System.Text.Json;
// using System.Text.Json.Serialization;
#endregion
namespace Variant_6
{
    public class Task4
    {
        public interface ISerializer
        {
            void Serialize(string path, object obj);
            object Deserialize(string path, Type type);
        }

        public class CommonSerializer
        {
            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Dispose();
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (var folderName in folderNames)
                {
                    Directory.CreateDirectory(Path.Combine(path, folderName));
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (var fileName in fileNames)
                {
                    File.Create(Path.Combine(path, fileName)).Dispose();
                }
            }
        }

        public class JSONSerializer : CommonSerializer, ISerializer
        {
            private Reverter _myReverter;
            public Reverter MyReverter => _myReverter;

            public void Serialize(string path, object obj)
            {
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            public object Deserialize(string path, Type type)
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject(json, type);
            }

            public void SaveReverter(string path, Reverter reverter)
            {
                _myReverter = reverter;
                Serialize(path, reverter);
            }

            public Reverter LoadReverter(string path)
            {
                _myReverter = (Reverter)Deserialize(path, typeof(Reverter));
                return _myReverter;
            }
        }

        public class Reverter
        {
            private string _input;
            private string _output;

            public string Input => _input;
            public string Output => _output;

            public Reverter(string text)
            {
                _input = text;
                _output = ReverseWordsInText(text);
            }

            private string ReverseWordsInText(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }

                // Регулярное выражение для разделения текста на слова и неслова
                string pattern = @"(\w+)|(\W+)";
                var matches = Regex.Matches(text, pattern);
                string result = string.Empty;

                foreach (Match match in matches)
                {
                    if (Regex.IsMatch(match.Value, @"\w+"))
                    {
                        result += ReverseWord(match.Value);
                    }
                    else
                    {
                        result += match.Value;
                    }
                }

                return result;
            }

            private string ReverseWord(string word)
            {
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }

            public override string ToString()
            {
                return _output ?? string.Empty;
            }
        }

        public static void Main(string[] args)
        {
            string inputText = "Hello, world! This is an example text.";
            Reverter reverter = new Reverter(inputText);
            Console.WriteLine("Input: " + reverter.Input);
            Console.WriteLine("Output: " + reverter.Output);

            JSONSerializer jsonSerializer = new JSONSerializer();
            string path = "reverter.json";
            jsonSerializer.SaveReverter(path, reverter);

            Reverter loadedReverter = jsonSerializer.LoadReverter(path);
            Console.WriteLine("Loaded Input: " + loadedReverter.Input);
            Console.WriteLine("Loaded Output: " + loadedReverter.Output);
        }
    }
}
