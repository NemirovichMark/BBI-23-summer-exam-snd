public class Task3
{
    public class Searcher
    {
        public string Input { get; }
        public string[] Output { get; }

        public Searcher(string input)
        {
            Input = input ?? throw new ArgumentNullException(nameof(input));
            Output = FindPalindromes(input).ToArray();
        }

        private IEnumerable<string> FindPalindromes(string text)
        {
            string[] words = text.Split(' ');
            foreach (var word in words)
            {
                if (word.Length > 1 && word.SequenceEqual(word.Reverse()))
                {
                    yield return word;
                }
            }
        }

        public override string ToString() => string.Join("\n", Output);
    }
}


