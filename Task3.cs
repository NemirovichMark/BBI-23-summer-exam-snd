using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            public string Input { get; private set; }
            public string Output { get; private set; }

            public Grep(string text)
            {
                Input = text;
                ProcessText();
            }

            private void ProcessText()
            {
                if (string.IsNullOrEmpty(Input))
                {
                    Output = string.Empty;
                    return;
                }

                var lowerCaseText = Input.ToLower();


                var letterCount = new Dictionary<char, int>();

                foreach (char c in lowerCaseText)
                {
                    if (char.IsLetter(c))
                    {
                        if (letterCount.ContainsKey(c))
                        {
                            letterCount[c]++;
                        }
                        else
                        {
                            letterCount[c] = 1;
                        }
                    }
                }

                char mostFrequentLetter = '\0';
                int maxCount = 0;

                foreach (var pair in letterCount)
                {
                    if (pair.Value > maxCount)
                    {
                        mostFrequentLetter = pair.Key;
                        maxCount = pair.Value;
                    }
                }

                var words = Regex.Split(Input, @"(\W+)");
                var filteredWords = new StringBuilder();

                foreach (var word in words)
                {
                    if (!word.ToLower().Contains(mostFrequentLetter))
                    {
                        filteredWords.Append(word);
                    }
                }

                Output = filteredWords.ToString().Trim();
            }

            public override string ToString()
            {
                return Output;
            }
        }
    }
}
