using System.Drawing;

namespace CalculatorThemes
{
    public interface IThemeFactory
    {
        Color GetBackgroundColor();
        Font GetFont();
        Color GetFontColor();
    }
}
