using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_1
{
    public class Task3
    {
        public class Searcher
        {
            private string input;
            private string[] output;

            public string Input
            {
                get { return input; }
            }

            public string[] Output
            {
                get { return output; }
            }

            public Searcher(string text)
            {
                input = text;
                Povtors();
            }

            private void Povtors()
            {
                output = input.Split(' ');
            }

            public override string ToString()
            {
                return string.Join(" ", output);
            }
        }
    }
}