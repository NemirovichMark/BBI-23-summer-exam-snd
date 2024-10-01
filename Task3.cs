using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string input;
            private string output = "";
            public string Input { get { return input; } }
            public string Output { get { return output; } }
            public Grep(string text)
            {
                if (text != null)
                {
                    input = text;
                }
                else { return; }
                char[] chars = { };
                string lowerInput = input.ToLower();
                foreach (char c in lowerInput)
                {
                    if (char.IsLetter(c))
                    {
                        if (!chars.Contains(c)) { chars = chars.Append(c).ToArray(); }
                    }
                }
                List<int> charscount = new List<int> { };
                foreach (var c in chars) { charscount.Add(lowerInput.Count(x => x == c)); }
                char maxChar = ' ';
                int max = 0;
                for (int i = 0; i < charscount.Count; i++)
                {
                    int count = charscount[i];
                    if (count > max) { max = count; maxChar = chars[i]; }
                }
                string[] words = input.Split(' ');
                foreach (string word in words)
                {
                    if (!word.ToLower().Contains(maxChar))
                    {
                        output += word + " ";
                    }
                }
            }
            public override string ToString()
            {
                return output;
            }
        }
    }
}