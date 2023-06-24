using System.Drawing;

namespace CalculatorThemes
{
    public class LightThemeFactory : IThemeFactory
    {
        public Color GetBackgroundColor()
        {
            return Color.White;
        }

        public Font GetFont()
        {
            return new Font("SimSun", 9);
        }

        public Color GetFontColor()
        {
            return Color.Black;
        }
    }

    public class DarkThemeFactory : IThemeFactory
    {
        public Color GetBackgroundColor()
        {
            return Color.Black;
        }

        public Font GetFont()
        {
            return new Font("Verdana", 9);
        }

        public Color GetFontColor()
        {
            return Color.White;
        }
    }

}
