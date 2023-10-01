using System.Text.RegularExpressions;

namespace Project_Work_Dictionary_
{
    static class MenuManager
    {
        public static void CreateDictionary(ref Dictionary<string, DictionaryManager> dictionaryes)
        {

            while (true)
            {
                string keyDict = SelectInterface();

                if (keyDict == "5")
                {
                    Console.Clear();
                    
                    break; 
                }

                Console.Clear();

                if (dictionaryes.ContainsKey(keyDict))
                {
                    Console.WriteLine("An instance of the selected dictionary already exists\n\n");
                }

                else
                {
                    dictionaryes.Add(keyDict, new DictionaryManager());

                    Console.WriteLine("The dictionary has been created\n\n");
                }
            }
        }

        public static void DeleteDictionary(ref Dictionary<string, DictionaryManager> dictionaryes)
        {
            while (true)
            {
                string keyDict = SelectInterface();

                if (keyDict == "5") 
                {
                    Console.Clear(); 
                    break;
                }

                Console.Clear();

                if (!dictionaryes.ContainsKey(keyDict))
                {
                    throw new Exception("The dictionary does not exist.");
                }

                dictionaryes.Remove(keyDict);

            }
        }

        public static void DictionaryManager(ref Dictionary<string, DictionaryManager> dictionaries)
        {
            Dictionary<string, string> patterns = new();

            patterns["RU"] = "^[А-Яа-я]+$";
            patterns["EN"] = "^[A-Za-z]+$";
            patterns["DE"] = @"^[\p{L}äöüß]+$";

            while (true)
            {
                string keyDict = SelectInterface();

                if (keyDict == "5") 
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();

                if (!dictionaries.ContainsKey(keyDict))
                {
                    Console.Write("This dictionary has not been created.\n" +
                                  "1. Create a dictionary.\n" +
                                  "2. Go back.\n" +
                                  "Enter selection - ");

                    string choice1 = Console.ReadLine();

                    if (!Regex.IsMatch(choice1.ToString(), "^[1-2]{1}$"))
                    {
                        throw new Exception("Input error in dictionary manager");
                    }

                    Console.Clear();

                    switch (choice1)
                    {
                        case "1":
                            dictionaries.Add(keyDict, new DictionaryManager());
                            break;
                        case "2":
                            continue;
                        default:
                            break;
                    }
                }

                bool key1 = true;

                while (key1)
                {
                    Console.Write("1. Find translation.\n" +
                                  "2. Add a new word and translation.\n" +
                                  "3. Add translation.\n" +
                                  "4. Change translation.\n" +
                                  "5. Print the entire dictionary.\n" +
                                  "6. Delete translation.\n" +
                                  "7. Go back.\n" +
                                  "Enter selection - ");

                    string choice2 = Console.ReadLine();

                    if (!Regex.IsMatch(choice2.ToString(), "^[1-7]{1}$"))
                    {
                        throw new Exception("Input error in dictionary manager");
                    }

                    Console.Clear();

                    switch (choice2)
                    {
                        case "1":

                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n" + "Enter word - ");

                                string word = Console.ReadLine();

                                if (word == "0") 
                                { 
                                    break;
                                }

                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    List<string> words = dictionaries[keyDict].GetTranslate(word);

                                    Console.Write($"{word} - ");

                                    for (int i = 0; i < words.Count; i++)
                                    {
                                        Console.WriteLine($"{words[i]} ");
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 1 (DictionaryManager) - " + e.Message);

                                    continue;
                                }

                                break;
                            }

                            Console.Clear();

                            break;

                        case "2":
                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n" + "Enter word - ");

                                string word = Console.ReadLine();

                                if (word == "0") 
                                { 
                                    break; 
                                }

                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");

                                    string wordTranslate = Console.ReadLine();

                                    if (!Regex.IsMatch(wordTranslate, patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Incorrect input language");
                                    }

                                    dictionaries[keyDict].Add(word, wordTranslate);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 2 (DictionaryManager) - " + e.Message);

                                    continue;
                                }

                                break;
                            }

                            Console.Clear();

                            break;

                        case "3":
                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");

                                string word = Console.ReadLine();

                                if (word == "0") 
                                { 
                                    break; 
                                }

                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");

                                    string wordTranslate = Console.ReadLine();

                                    if (!Regex.IsMatch(wordTranslate, patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaries[keyDict].AddTranslate(word, wordTranslate);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 3 (DictionaryManager) - " + e.Message);

                                    continue;
                                }

                                break;
                            }

                            Console.Clear();

                            break;

                        case "4":

                            Dictionary<string, List<string>> dictionary = dictionaries[keyDict].GetDictionary();

                            foreach (var item in dictionary)
                            {
                                Console.Write($"{item.Key} - ");

                                for (int i = 0; i < item.Value.Count; i++)
                                {
                                    Console.Write($"{item.Value[i]} ");
                                }

                                Console.WriteLine("\n");
                            }

                            Console.WriteLine("\n");

                            break;

                        case "5":

                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");

                                string word = Console.ReadLine();

                                if (word == "0") 
                                {  
                                    break; 
                                }

                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");

                                    string wordTranslate = Console.ReadLine();

                                    if (!Regex.IsMatch(wordTranslate.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaries[keyDict].DeleteTranslate(word, wordTranslate);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 4 (DictionaryManager) - " + e.Message);

                                    continue;
                                }

                                break;
                            }

                            Console.Clear();

                            break;

                        case "6":
                            while (true)
                            {

                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");

                                string word = Console.ReadLine();

                                if (word == "0") 
                                { 
                                    break;
                                }

                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");

                                    string wordTranslate = Console.ReadLine();

                                    if (!Regex.IsMatch(wordTranslate.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter new translete - ");

                                    string newWordTranslate = Console.ReadLine();

                                    if (!Regex.IsMatch(newWordTranslate.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaries[keyDict].ChangeTranslate(word, wordTranslate, newWordTranslate);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 5 (DictionaryManager) - " + e.Message);

                                    continue;
                                }

                                break;
                            }

                            Console.Clear();

                            break;
                        case "7":
                            key1 = false;

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static string SelectInterface()
        {
            Console.Write("Select a dictionary to delete:\n" +
                          "1. Russian-English dictionary\n" +
                          "2. English-Russian\n" +
                          "3. Russian-Deutsche\n" +
                          "4. Deutsche-Russian\n" +
                          "5. Exit\n" +
                          "Enter choice - ");

            string choice = Console.ReadLine();

            if (!Regex.IsMatch(choice.ToString(), "^[1-5]{1}$"))
            {
                throw new Exception("Input error");
            }

            string[] arrKey = new string[5] { "RU-EN", "EN-RU", "RU-DE", "DE-RU", "5" };

            string keyDict = arrKey[int.Parse(choice) - 1];

            return keyDict;
        }
    }
}