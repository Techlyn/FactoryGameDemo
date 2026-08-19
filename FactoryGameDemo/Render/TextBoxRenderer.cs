using FactoryGameDemo.Core;
using FactoryGameDemo.Utility;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
namespace FactoryGameDemo.Render;

public class TextBoxRenderer(TextSettings settings) : TextRenderer(settings)
{

    public Box Box { get; set; } = new Box();
    protected float Padding = 1.0f;
    protected Color BackgroundColor = Color.White;


    public virtual void Init(string text, Vector2<float> position, float font_size, float padding, float spacing = 1.0f, Color? text_color = null, Color? bgColor = null)
    {
        base.Init(text, position, font_size, spacing, text_color);
        Box.Position = position;
        Padding = padding;
        BackgroundColor = bgColor ?? Color.White;


        Layout();
    }

    private void Layout()
    {
        Core.Vector2<float> textMeasurements = Measure(Text, FontSize, Spacing);
        Box.Size = textMeasurements;
        Box.Size += Padding;
        TextPosition = Box.Position;
        TextPosition += Padding/2;

    }

    public void CenterTextBox()
    {
        Core.Vector2<float> newPosition = Box.Position;
        newPosition -= Box.Size/2;
        Box.Position = newPosition;
        TextPosition = Box.Position;
        TextPosition += Box.Size / 2;
        Core.Vector2<float> textMeasurements = Measure(Text, FontSize, Spacing);
        TextPosition -= textMeasurements / 2;
    }

    public void CenterTextBoxX()
    {
        Core.Vector2<float> newPosition = Box.Position;
        newPosition.X -= Box.Size.X / 2;
        Box.Position = newPosition;
        TextPosition.X = newPosition.X;
        TextPosition.X += Padding / 2;
    }
    public void CenterToxBoxY()
    {
        Core.Vector2<float> newPosition = Box.Position;
        newPosition.Y -= Box.Size.Y / 2;
        Box.Position = newPosition;
        TextPosition.Y = newPosition.Y;
        TextPosition.Y += Padding / 2;
    }

    public virtual void Draw()
    {
        BoxRenderer.DrawBoxFilled(Box, BackgroundColor);
        BoxRenderer.DrawBoxLine(Box, TextColor);
        base.Draw();
    }

    
}
