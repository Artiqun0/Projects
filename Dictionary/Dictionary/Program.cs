using Project_Work_Dictionary_;
using System.Text.RegularExpressions;

bool key = true;

Dictionary<string, List<string>> files = new();

try
{
    files = FilesWork.FileExport("Files.csv");
}
catch (Exception) { }

Dictionary<string, DictionaryManager> dictionaryes = new();

try
{
    for (int i = 0; i < files["files"].Count - 1; i++)
    {
        dictionaryes[files["files"][i]] = new DictionaryManager(FilesWork.FileExport(files["files"][i] + ".csv"));
    }
}
catch (Exception) { }


while (key)
{
    Console.Write("1. Create a dictionary\n" +
                  "2. Delete dictionary\n" +
                  "3. Select a dictionary\n" +
                  "4. Exit.\n" +
                  "Enter choice - ");

    string choice = Console.ReadLine();

    Console.Clear();

    try
    {
        if (!Regex.IsMatch(choice, "^[1-4]{1}$"))
        {
            throw new Exception("Input error");
        }
    }
    catch (Exception excep)
    {
        Console.WriteLine(excep.Message);
    }

    switch (choice)
    {
        case "1":
            try
            {
                MenuManager.CreateDictionary(ref dictionaryes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case "2":
            try
            {
                MenuManager.DeleteDictionary(ref dictionaryes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case "3":
            try
            {
                MenuManager.DictionaryManager(ref dictionaryes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case "4":
            Dictionary<string, List<string>> file = new();

            file["files"] = new List<string>();

            foreach (var item in dictionaryes)
            {
                FilesWork.FileImport(item.Value.GetDictionary(), item.Key);

                file["files"].Add(item.Key);
            }

            for (int i = 0; i < file["files"].Count; i++)
            {
                FilesWork.FileImport(file, "Files");
            }

            key = false;

            break;
        default:
            break;
    }
}
