using FactoryGameDemo.Render;
using FactoryGameDemo.Utility;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using FactoryGameDemo.Core;
using System.Drawing;
using System.Security.Cryptography;

namespace FactoryGameDemo.Scenes;

public class MainMenuScene
{
    private readonly Vector2<float> _windowSize;

    private string _titleText = "Factory Game Co";

    private TextSettings _textSettings;
    
    private TextRenderer _titleTextRenderer;
    private List<MenuButton> _buttons;


    public MainMenuScene(string font_path)
    {
        if(font_path == null)
        {
            Console.WriteLine("font path null, default font path given");
            font_path = "resources/arial.ttf";
        }
        _windowSize = new Vector2<float>(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT);

        LoadContent(font_path);
        CalculateLayout();
    }

    private void LoadContent(string font_path)
    {
        _textSettings = new TextSettings(font_path);


        _titleTextRenderer = new TextRenderer(_textSettings);


        _buttons = new List<MenuButton>
        {
            new MenuButton("Continue", _textSettings, Input.MseButton.Left),
            new MenuButton("New Game", _textSettings, Input.MseButton.Left),
            new MenuButton("Load", _textSettings, Input.MseButton.Left),
            new MenuButton("Settings", _textSettings, Input.MseButton.Left),
            new MenuButton("Quit", _textSettings, Input.MseButton.Left),
        };


    }

    private void CalculateLayout()
    {
        Vector2<float> startPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.TopCenter);
        
        float titleFontSize = 40;
        _titleTextRenderer.Init(_titleText, startPos, titleFontSize);
        _titleTextRenderer.CenterOnPosX(_titleText, titleFontSize);
        

        startPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.Center);
        startPos.Y -= _windowSize.Y / 4;
        float fontSize = 26;
        float padding = 30;
        Vector2<float> totalPosMovement = startPos;

        List<float> list = [];

        foreach (var button in _buttons)
        {
            
            Box box = new Box(totalPosMovement, new Vector2<float>(0, 0));
            button.Init(totalPosMovement,fontSize, padding);
            totalPosMovement.Y += padding * 2;
            list.Add(button.ButtonRenderer.Box.Size.X);


        }
        float largest = list.Max();
        foreach(MenuButton button in _buttons)
        {
            Vector2<float> tempSize = button.ButtonRenderer.Box.Size;
            tempSize.X = largest;
            button.ButtonRenderer.Box.Size = tempSize;
            button.ButtonRenderer.CenterTextBox();

        }
        

    }

    public void Update()
    {
        Vector2<int> mousePos = Input.Input.MousePosition();
        foreach (MenuButton button in _buttons)
        {
            button.Update(Vector2<int>.ToFloat(mousePos));
        }
    }

    public void Draw()
    {
        BackgroundColor.ClearBackground(Raylib_cs.Color.White);
        Vector2<float> titlePos = LayoutHelper.GetPosition(LayoutHelper.Anchor.TopCenter);
        _titleTextRenderer.Draw();

       

        Vector2<float> buttonPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.Center);
        foreach (MenuButton button in _buttons)
        { 
            button.Draw();
        }
    }
    



}
