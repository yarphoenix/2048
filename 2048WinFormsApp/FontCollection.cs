using System.Drawing.Text;

namespace _2048WinFormsApp;

internal static class FontCollection
{
    private static readonly PrivateFontCollection Fonts = new();
    private static readonly Dictionary<string, FontFamily> Map = new(StringComparer.OrdinalIgnoreCase);

    // Ключи — имена файлов в папке "Fonts"
    private const string FontsFolderName = "Fonts";

    public static FontFamily FoglihtenBlackPcs => GetByFileKey("FoglihtenBlackPcs.ttf");
    public static FontFamily Aladdin => GetByFileKey("Aladdin.ttf");
    public static FontFamily AFuturaRound => GetByFileKey("a_FuturaRound.ttf");

    static FontCollection()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string fontsDirectory = Path.Combine(baseDirectory, FontsFolderName);

        var files = new[]
        {
            "FoglihtenBlackPcs.ttf",
            "Aladdin.ttf",
            "a_FuturaRound.ttf"
        };

        foreach (string file in files)
            LoadFontFile(Path.Combine(fontsDirectory, file), file);
    }

    private static void LoadFontFile(string path, string fileKey)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Font file not found: {path}. Убедитесь, что файл копируется в выходную папку (Copy to Output Directory).");

        string[] beforeAdd = Fonts.Families.Select(ff => ff.Name).ToArray();

        Fonts.AddFontFile(path);

        string[] afterAdd = Fonts.Families.Select(ff => ff.Name).ToArray();

        string[] added = afterAdd.Except(beforeAdd, StringComparer.OrdinalIgnoreCase).ToArray();

        FontFamily? family;

        switch (added.Length)
        {
            case 1:
            case > 1:
                family = Fonts.Families.First(ff => ff.Name.Equals(added[0], StringComparison.OrdinalIgnoreCase));
                break;
            default:
            {
                string keyWithoutExtension = Path.GetFileNameWithoutExtension(fileKey);
                family = Fonts.Families.FirstOrDefault(ff => ff.Name.IndexOf(keyWithoutExtension, StringComparison.OrdinalIgnoreCase) >= 0);

                if (family == null)
                {
                    if (Fonts.Families.Length > 0)
                        family = Fonts.Families.Last();
                    else
                        throw new InvalidOperationException($"Не удалось определить FontFamily для файла '{fileKey}' после загрузки. Проверьте, что файл корректный TTF/OTF.");
                }

                break;
            }
        }

        Map[fileKey] = family;
    }

    private static FontFamily GetByFileKey(string fileName)
    {
        if (Map.TryGetValue(fileName, out var fam))
            return fam;

        string available = Fonts.Families.Length == 0
            ? "<no loaded families>"
            : string.Join(", ", Fonts.Families.Select(f => f.Name));

        throw new InvalidOperationException($"Font for key '{fileName}' not found. Available families: {available}");
    }

    public static string[] GetAvailableFamilyNames()
    {
        return Fonts.Families.Select(f => f.Name).ToArray();
    }
}