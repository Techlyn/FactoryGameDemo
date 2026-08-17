using FactoryGameDemo.Render;
using FactoryGameDemo.Utility;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace FactoryGameDemo.Scenes;



public class MenuButton
{
    public string Text { get; }
    public TextBoxRenderer TextBoxRenderer { get; }
    public Input.MseButton Button { get; }
    public Box? Bounds { get; private set; }
    public Action? OnClick { get; }
    public bool IsHovered { get; private set; }
    public Core.Vector2<float> TextSize { get; private set; }

    public MenuButton(string text,TextBoxRenderer textBoxRenderer, Input.MseButton button)
    {
        Text = text;
        TextBoxRenderer = textBoxRenderer;
        Button = button;
    }

    public void SetLayout(Core.Vector2<float> position, Core.Vector2<float> textSize)
    {
        TextSize = textSize;
        Core.Vector2<float> paddedSize = textSize + new Core.Vector2<float>(40, 20);
        Bounds = new Box(position, paddedSize);
    }

    public void Update(Core.Vector2<float> mousePosition)
    {
        if (Bounds == null) return;
        IsHovered = Collisions.BoxContainsMouse(Bounds, mousePosition);
        if (IsHovered && (Input.Input.MousePressed() == Input.MseButton.Left))
        {
            OnClick?.Invoke();
        }
    }

    public void Draw(Core.Vector2<float> pos, float size)
    {
        if (Bounds == null) return;
        Color bgColor = IsHovered ? Color.Red : Color.White;

        BoxRenderer.DrawBoxFilled(Bounds, bgColor);
        BoxRenderer.DrawBoxLine(Bounds, Color.Black);

        Core.Vector2<float> textPos = new Core.Vector2<float>(Bounds.Position.X + 20, Bounds.Position.Y + 10) + pos;
        TextBoxRenderer.Draw(Text, textPos, size);
    }

}
