using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryGameDemo.Utility
{
    public interface IFont
    {
        float Size { get; }
        float Spacing { get; }
        Color Color { get; }
    }

    public sealed class FontSettings : IFont
    {
        public float Size { get; }
        public float Spacing { get; }
        public Color Color { get; }

        private FontSettings(float size, float spacing, Color color)
        {
            Size = size;
            Spacing = spacing;
            Color = color;
        }

        public static FontSettings Create(float size, float spacing = 1, Color? color = null) =>
            new FontSettings(size, spacing, color ?? Color.Black);

        public FontSettings WithSize(float newSize) => new FontSettings(newSize, Spacing, Color);
        public FontSettings WithSpacing(float newSpacing) => new FontSettings(Size, newSpacing, Color);
        public FontSettings WithColor(Color newColor) => new FontSettings(Size, Spacing, newColor);
    }
}
