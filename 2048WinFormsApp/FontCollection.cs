using System.Drawing.Text;

namespace _2048WinFormsApp;

internal static class FontCollection
{
    private static readonly PrivateFontCollection Fonts = new();

    public static FontFamily FoglihtenBlackPcs => GetFontFamily("FoglihtenBlackPcs");
    public static FontFamily Aladdin => GetFontFamily("Aladdin");
    public static FontFamily AFuturaRound => GetFontFamily("a_FuturaRound");

    static FontCollection()
    {
        Fonts.AddFontFile(Path.Combine(Application.StartupPath, "FoglihtenBlackPcs.ttf"));
        Fonts.AddFontFile(Path.Combine(Application.StartupPath, "Aladdin.ttf"));
        Fonts.AddFontFile(Path.Combine(Application.StartupPath, "a_FuturaRound.ttf"));
    }

    private static FontFamily GetFontFamily(string familyName)
    {
        return Fonts.Families.First(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));
    }
}