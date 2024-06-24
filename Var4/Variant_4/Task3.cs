using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
    public class Task3
    {
        public class Uniques
        {
            public string Input { get; private set; }
            public string[] Output { get; private set; }

            public Uniques(string text)
            {
                Input = text;
                if (text != null)
                {
                    FindAns();
                }
            }

            private void FindAns()
            {
                char[] delimiters = new char[] { ' ', ',', '.', '!', '?', ':', ';', '\n', '\r' };
                string[] strings = Input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                List<string> list = new List<string>();
                foreach (string s in strings)
                {
                    if (CheckRepeats(s) && s.Length > 1)
                    {
                        list.Add(s);
                    }
                }

                Output = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    Output[i] = list[i];
                }
            }

            private bool CheckRepeats(string word)
            {
                List<char> set = new List<char>();
                foreach (char c in word)
                {
                    if (set.Contains(c))
                    {
                        return false;
                    }

                    set.Add(c);
                }

                return true;
            }

            public override string ToString()
            {
                string ans = "";
                foreach (string s in Output)
                {
                    ans += s + "\n";
                }

                return ans;
            }
        }
    }
}
