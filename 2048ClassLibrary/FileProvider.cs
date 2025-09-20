using System.Text;

namespace _2048ClassLibrary;

public static class FileProvider
{
    public static void Append(string fileName, string value)
    {
        using var writer = new StreamWriter(fileName, true, Encoding.UTF8);
        writer.WriteLine(value);
    }

    public static void Replace(string fileName, string value)
    {
        using var writer = new StreamWriter(fileName, false, Encoding.UTF8);
        writer.WriteLine(value);
    }

    public static string Get(string fileName)
    {
        using var reader = new StreamReader(fileName, Encoding.UTF8);
        string value = reader.ReadToEnd();
        return value;
    }

    public static bool Exists(string fileName) => File.Exists(fileName);

    public static void Clear(string filePath) => File.WriteAllText(filePath, string.Empty);
}