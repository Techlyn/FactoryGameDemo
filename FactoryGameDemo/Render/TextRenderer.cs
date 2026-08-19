using FactoryGameDemo.Core;
using FactoryGameDemo.Utility;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactoryGameDemo.Render;

// Remove textSize from other areas of the program, 



public class TextRenderer
{
    protected TextSettings Settings;
    protected string Text = "";
    protected Core.Vector2<float> TextPosition = new Core.Vector2<float>(0,0);
    protected float FontSize = 30;
    protected float Spacing = 1;
    protected Color TextColor = Color.Black;


    public TextRenderer(TextSettings settings)
    {
        Settings = settings;
    }

    public virtual void Init(string text, Core.Vector2<float> text_position, float font_size, float spacing = 1.0f, Color? text_color = null)
    {
        Text = text;
        TextPosition = text_position;
        FontSize = font_size;
        Spacing = spacing;
        TextColor = text_color ?? Color.Black;
    }
    
    public Core.Vector2<float> Measure(string text, float size, float spacing)
    {
       
        System.Numerics.Vector2 result = Raylib.MeasureTextEx(Settings.FONT, text, size, spacing);
        return new Core.Vector2<float>(result.X, result.Y);
    }
    public void CenterOnPosX(string text, float size, float spacing = 1.0f)
    {
        Vector2<float> textSizeMeasurement = Measure(text, size, spacing);
        TextPosition.X -= textSizeMeasurement.X / 2;
    }

    public void CenterOnPosY(string text, float size, float spacing = 1.0f)
    {
        Vector2<float> textSizeMeasurement = Measure(text, size, spacing);
        TextPosition.Y -= textSizeMeasurement.Y / 2;
    }

    public virtual void Draw()
    {
        Raylib.DrawTextEx(Settings.FONT, Text, new Vector2(TextPosition.X, TextPosition.Y), FontSize, Spacing, TextColor);
    }

}
