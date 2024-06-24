using System;
using System.Collections.Generic;
using System.Linq;

namespace Variant_4
{
    public class Task3
    {
        public class Uniques
        {
            private string _input;
            public string Input
            {
                get { return _input; }
            }

            private string[] _output;
            public string[] Output
            {
                get { return _output; }
            }

            public Uniques(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    _input = input;
                    _output = Array.Empty<string>();
                }
                else
                {
                    _input = input.ToLower();
                    string[] words = _input.Split(' ');
                    List<string> uniqueWords = new List<string>();

                    foreach (string word in words)
                    {
                        if (HasDuplicateLetters(word) && !uniqueWords.Contains(word))
                        {
                            uniqueWords.Add(word);
                        }
                    }

                    _output = uniqueWords.ToArray();
                }
            }

            private bool HasDuplicateLetters(string word)
            {
                bool[] letters = new bool[26];
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (char.IsLetter(c))
                    {
                        int index = char.ToLower(c) - 'a';
                        if (index < 0 || index >= 26)
                        {
                            
                            continue;
                        }
                        if (letters[index])
                        {
                            return true;
                        }
                        letters[index] = true;
                    }
                }
                return false;
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, _output);
            }
        }
    }
}