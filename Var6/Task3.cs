using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Variant_6
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
        string inputText = "Объектно-ориентированное программирование направлено на реализацию в программировании сущностей реального мира, " +
                "таких как наследование, сокрытие, полиморфизм и т. д. " +
                "Основная цель ООП состоит в том, чтобы связать воедино данные и функции, которые с ними работают, " +
                "таким образом, чтобы никакая другая часть кода не могла получить доступ к этим данным, кроме этой функции.";
        Reverter reverter = new Reverter(inputText);
        Console.WriteLine("Input: " + reverter.Input);
        Console.WriteLine("Output: " + reverter.Output);
    }
}

