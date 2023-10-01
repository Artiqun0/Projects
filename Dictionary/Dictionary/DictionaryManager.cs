namespace Project_Work_Dictionary_
{
    internal class DictionaryManager
    {
        private Dictionary<string, List<string>> Dict;

        public DictionaryManager() { Dict = new(); }

        public DictionaryManager(Dictionary<string, List<string>> dictionary)
        {
            Dict = dictionary;
        }

        public void Add(string key, string value)
        {
            List<string> list = new List<string>() { value };

            Dict.Add(key, list);
        }

        public void AddTranslate(string key, string value)
        {
            if (Dict[key].Count == 10)
            {
                throw new InvalidOperationException("The value cannot be added, the maximum number of translation options has been reached.");
            }
            else
            {
                Dict[key].Add(value);
            }
        }

        public void ChangeTranslate(string key, string word, string newWord)
        {
            foreach (var item in Dict[key])
            {
                if (item.Equals(word))
                {
                    Dict[key].WordReplace(word, newWord);
                }
                else
                {
                    throw new Exception("This translation is not in the dictionary.");
                }
            }
        }
        public List<string> GetTranslate(string key)
        {
            if (!Dict.ContainsKey(key))
            {
                throw new Exception("There's no such word in the dictionary.");
            }

            return Dict[key];
        }

        public void DeleteTranslate(string key, string value)
        {
            if (Dict[key].Count == 1)
            {
                throw new Exception("The value cannot be deleted.");
            }

            else
            {
                foreach (var item in Dict[key])
                {
                    if (item.Equals(value))
                    {
                        Dict[key].Remove(item);
                    }
                }
            }
        }

        public Dictionary<string, List<string>> GetDictionary()
        {
            return Dict;
        }
    }
}