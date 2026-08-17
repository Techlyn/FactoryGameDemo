using FactoryGameDemo.Core;
using FactoryGameDemo.Utility;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactoryGameDemo.Render;

// Remove textSize from other areas of the program, 



public class TextRenderer : IDisposable
{
    public Font FONT;


    public TextRenderer(string resource_path)
    {
        FONT = Raylib.LoadFontEx(resource_path, 32, null, 0);
        Raylib.SetTextureFilter(FONT.Texture, TextureFilter.Point);
    }
    
    public Core.Vector2<float> Measure(string text, float size, float spacing)
    {
       
        System.Numerics.Vector2 result = Raylib.MeasureTextEx(FONT, text, size, spacing);
        return new Core.Vector2<float>(result.X, result.Y);
    }

    public void Draw(string text, Core.Vector2<float> pos, float size, float spacing = 1.0f, Color? color = null, bool margin = false)
    {
        Core.Vector2<float> position = pos;
        position.X -= Measure(text, size, spacing).X / 2;
        Raylib.DrawTextEx(FONT, text,new Vector2(position.X, position.Y), size, spacing, color ?? Color.Black);
    }

    public virtual void Draw(string text, Vector2<float> pos, float size, float padding, float spacing = 1, Color? color = null, bool margin = false) 
        => Draw(text, pos, size, spacing, color, margin);
    

    
    

    public void Dispose()
    {
        Raylib.UnloadFont(FONT);
    }
}
