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
    public Box? Box { get; set; }
    public Action? OnClick { get; }
    public bool IsHovered { get; private set; }
    

    public MenuButton(string text, TextBoxRenderer textBoxRenderer, Input.MseButton button)
    {
        Text = text;
        TextBoxRenderer = textBoxRenderer;
        Button = button;
        Box = new Box(new Core.Vector2<float>(0, 0), new Core.Vector2<float>(0, 0));
    }

    //public void Layout(Box box)
    //{
    //    Box = box;
    //}

    public void Update(Core.Vector2<float> mousePosition)
    {
        

        IsHovered = Collisions.BoxContainsMouse(TextBoxRenderer.Box, mousePosition);
        if (IsHovered && (Input.Input.MousePressed() == Input.MseButton.Left))
        {
            OnClick?.Invoke();
        }
    }

    public void Draw(Core.Vector2<float> pos, float size, float padding = 0, float spacing = 1, Color? color = null)
    {
       

        Color bgColor = IsHovered ? Color.Red : Color.White;

        
        TextBoxRenderer.Draw(Text, pos, size, padding, spacing, color ?? Color.Black, bgColor);
        
    }

}
