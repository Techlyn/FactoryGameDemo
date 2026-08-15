using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using FactoryGameDemo.Utility;
using Raylib_cs;

namespace FactoryGameDemo.Render;

public static class TextRenderer
{
    private static Font GetNativeFont(string location)
    {
        return Raylib.LoadFont(location);
    }
    public static Core.Vector2<float> Measure( string text, IFont font)
    {
        Font nativeFont = GetNativeFont(font.Location);
        System.Numerics.Vector2 result = Raylib.MeasureTextEx(nativeFont, text, font.Size, font.Spacing);
        return new Core.Vector2<float>(result.X, result.Y);
    }

    public static void Draw(string text, IFont font, Core.Vector2<float> position)
    {
        Font nativeFont = GetNativeFont(font.Location);
        Raylib.DrawTextEx(nativeFont, text,new Vector2(position.X, position.Y), font.Size, font.Spacing, font.Color);
    }
}
