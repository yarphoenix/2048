namespace _2048WinFormsApp;

public static class TileStyleManager
{
    // Параметры нормализации экспоненты
    // minExp = 1 (2^1 = 2), maxExp = 11 (2^11 = 2048)
    private const int MinExp = 1;

    private const int MaxExp = 11;

    // Основные опорные цвета (пастельный светлый -> красный -> чёрный)
    private static readonly Color LightPastel = ColorTranslator.FromHtml("#FFF6F5"); // очень светлый тёплый фон
    private static readonly Color MidRed = ColorTranslator.FromHtml("#FF6B6B"); // насыщенный, но не кричащий красный
    private static readonly Color Black = Color.Black;

    private static readonly Color EmptyBackground = ColorTranslator.FromHtml("#EFE9E2");

    public static readonly Font DefaultFont = new("Yu Gothic UI Semibold", 20F, FontStyle.Bold);

    private static readonly Dictionary<float, Font> FontCache = new();

    /// <summary>
    ///     Применить стиль к Label. Можно передать baseFont (рекомендуется переиспользовать шрифт из формы).
    /// </summary>
    public static void ApplyStyle(Label lbl, int? value, Font? baseFont = null)
    {
        if (lbl == null) return;
        var fontToUse = baseFont ?? DefaultFont;

        if (!value.HasValue)
        {
            lbl.Text = string.Empty;
            lbl.BackColor = EmptyBackground;
            lbl.ForeColor = GetReadableTextColor(EmptyBackground);
            lbl.Font = GetOrAddFont(fontToUse.FontFamily, fontToUse.Style, fontToUse.Size);
            return;
        }

        int v = value.Value;
        lbl.Text = v.ToString();

        var bg = ComputeGradientColorForValue(v);
        lbl.BackColor = bg;

        // цвет текста — контрастный (белый/тёмный) в зависимости от яркости фона
        lbl.ForeColor = GetReadableTextColor(bg);

        // размер шрифта по длине значения, с кешированием
        float size = GetFontSizeForValue(v, fontToUse.Size);
        lbl.Font = GetOrAddFont(fontToUse.FontFamily, fontToUse.Style, size);
    }

    private static Color ComputeGradientColorForValue(int v)
    {
        if (v <= 0) return EmptyBackground;

        double exp = Math.Log(v, 2);
        double t = (exp - MinExp) / (MaxExp - MinExp);

        if (double.IsNaN(t)) t = 0;

        if (t <= 0.5)
        {
            double u = SafeNormalize(t, 0.0, 0.5);
            u = EaseInOutCubic(u);
            return LerpColor(LightPastel, MidRed, u);
        }
        else
        {
            double u = SafeNormalize(t, 0.5, 1.0);
            u = EaseInOutCubic(u);
            double uc = Math.Min(u, 1.0);
            return LerpColor(MidRed, Black, uc);
        }
    }

    private static double SafeNormalize(double x, double a, double b)
    {
        return (x - a) / (b - a);
    }

    private static double EaseInOutCubic(double x)
    {
        if (x < 0) return 0;
        if (x > 1) return 1;
        return x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
    }

    // Линейная интерполяция между двумя цветами (в пространстве RGB)
    private static Color LerpColor(Color a, Color b, double t)
    {
        t = Math.Clamp(t, 0.0, 1.0);
        var r = (int)Math.Round(a.R + (b.R - a.R) * t);
        var g = (int)Math.Round(a.G + (b.G - a.G) * t);
        var bl = (int)Math.Round(a.B + (b.B - a.B) * t);
        return Color.FromArgb(r, g, bl);
    }

    private static Color GetReadableTextColor(Color bg)
    {
        double luminance = 0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B;
        return luminance > 150 ? ColorTranslator.FromHtml("#2B2B2B") : Color.White;
    }

    private static float GetFontSizeForValue(int v, float baseSize)
    {
        int len = v.ToString().Length;
        return len switch
        {
            <= 3 => baseSize,
            4 => Math.Max(10f, baseSize - 2f),
            5 => Math.Max(8f, baseSize - 4f),
            6 => Math.Max(7f, baseSize - 6f),
            _ => Math.Max(6f, baseSize - 8f)
        };
    }

    private static Font GetOrAddFont(FontFamily family, FontStyle style, float size)
    {
        float keySize = (float)Math.Round(size * 4f) / 2f;
        if (FontCache.TryGetValue(keySize, out var cached)) return cached;

        var f = new Font(family, keySize, style);
        FontCache[keySize] = f;
        return f;
    }
}