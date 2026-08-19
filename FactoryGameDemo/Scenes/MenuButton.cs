using FactoryGameDemo.Render;
using FactoryGameDemo.Utility;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactoryGameDemo.Scenes;



public class MenuButton
{
    public string Text { get; }
    public ButtonRenderer ButtonRenderer { get; set; }
    public TextSettings TextSettings { get; }
    public Input.MseButton ButtonInput { get; }
    public Action? OnClick { get; }
    public bool IsHovered { get; private set; }


    public MenuButton(string text, TextSettings text_settings, Input.MseButton button_input)
    {
        Text = text;
        TextSettings = text_settings;
        ButtonInput = button_input;
        ButtonRenderer = new ButtonRenderer(text_settings);
    }

    public void Init(Core.Vector2<float> position, float font_size, float padding, float spacing = 1.0f, Color? text_color = null, Color? bgColor = null)
    {
        ButtonRenderer.Init(Text, position, font_size, padding, spacing, text_color, bgColor);
    }




    public void Update(Core.Vector2<float> mousePosition)
    {
        IsHovered = Collisions.BoxContainsMouse(ButtonRenderer.CollectButtonBox(), mousePosition);
        Color bgColor = IsHovered ? Color.Red : Color.White;
        ButtonRenderer.ChangeBackgroundColor(bgColor);
        if (IsHovered && (Input.Input.MousePressed() == Input.MseButton.Left))
        {
            OnClick?.Invoke();
        }
    }

    public void Draw()
    {
        ButtonRenderer.Draw();
    }

}
