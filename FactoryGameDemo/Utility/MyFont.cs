using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryGameDemo.Utility
{
    public interface IFont
    {
        string Location { get; }
        float Size { get; }
        float Spacing { get; }
        Color Color { get; }
    }

    public sealed class FontSettings : IFont
    {
        public string Location { get; }
        public float Size { get; }
        public float Spacing { get; }
        public Color Color { get; }

        private FontSettings(string location, float size, float spacing, Color color)
        {
            Location = location;
            Size = size;
            Spacing = spacing;
            Color = color;
        }

        public static FontSettings Create(string location, float size, float spacing = 1, Color? color = null) =>
            new FontSettings(location, size, spacing, color ?? Color.Black);

        public FontSettings WithSize(float newSize) => new FontSettings(Location, newSize, Spacing, Color);
        public FontSettings WithSpacing(float newSpacing) => new FontSettings(Location, Size, newSpacing, Color);
        public FontSettings WithColor(Color newColor) => new FontSettings(Location, Size, Spacing, newColor);
    }
}
