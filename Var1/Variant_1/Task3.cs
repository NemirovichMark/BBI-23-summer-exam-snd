using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Variant_1
{
    public class Task3
    {
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

                char[] separators = new char[] { ' ', '\t', '\n', '.', ',', '!', '?', ';', ':', '-', '_', '(', ')', '[', ']', '{', '}', '"', '\'' };
                string[] words = text.Split(separators, StringSplitOptions.None);

                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        string reversedWord = ReverseWord(word);
                        text = Regex.Replace(text, $@"\b{word}\b", reversedWord);
                    }
                }

                return text;
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

        //public static void Main(string[] args)
        //{
        //    string inputText = "Hello, world! This is an example text.";
        //    Reverter reverter = new Reverter(inputText);
        //    Console.WriteLine("Input: " + reverter.Input);
        //    Console.WriteLine("Output: " + reverter.Output);
        //}
    }
}

