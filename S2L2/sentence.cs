namespace S2L2
{
    class Sentence
    {
        public string sentence;

        public void Add(string word)
        {
            sentence += " " + word;
        }
        public void Remove(string word)
        {
            var words = sentence.Split(' ').ToList();
            if (words.Contains(word))
                words.Remove(word);
            else
                Console.WriteLine("Речення не містить дане слово");
            sentence = string.Join(' ', words);

        }
        public void InsertWord(int index, string word)
        {
            var words = sentence.Split(' ').ToList();
            if (index >= 0 && index < words.Count)
            {
                words.Insert(index, word);
                sentence = string.Join(' ', words);
            }
        }
        public int LetterCount()
        {
            return sentence.Replace(" ", "").Length;
        }
        public int WordCount()
        {
            var words = sentence.Split(' ').ToList();
            return words.Count;
        }
        public string LongestWord()
        {
            return sentence.Split(' ').ToList().OrderByDescending(i => i.Length).First();
        }
        public string ShortestWord()
        {
            return sentence.Split(' ').ToList().OrderBy(i => i.Length).First();
        }
        public bool IsContainWord(string word)
        {
            return sentence.Split(' ').Contains(word);
        }
        public string WordByIndex(int index)
        {
            var words = sentence.Split(' ').ToList();
            if (index >= 0 && index < words.Count)
                return words[index];
            else
                Console.WriteLine("Рядок не містить слова за даним індексом");
            return null;
        }
        public bool IsSentencesEqual(string sentence2)
        {
            return sentence == sentence2;
        }
    }
}
