using System.Text;

namespace Project_Work_Dictionary_
{
    static class FilesWork
    {
        public static void FileImport(Dictionary<string, List<string>> data, string fileName)
        {
            using (var writer = new StreamWriter(fileName + ".csv", false, Encoding.UTF8))
            {
                foreach (var pair in data)
                {
                    string key = pair.Key;

                    string values = string.Join(";", pair.Value);

                    writer.WriteLine($"{key};{values};");
                }
            }
        }

        public static Dictionary<string, List<string>> FileExport(string fileName)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length >= 2)
                    {
                        string key = parts[0];

                        List<string> values = parts.Skip(1).ToList();

                        data[key] = values;
                    }
                }
            }

            return data;
        }
    }
}