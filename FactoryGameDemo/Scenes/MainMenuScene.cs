using FactoryGameDemo.Render;
using FactoryGameDemo.Utility;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using FactoryGameDemo.Core;
using System.Drawing;
using System.Security.Cryptography;

namespace FactoryGameDemo.Scenes
{
    public class MainMenuScene
    {
        private readonly Vector2<float> _windowSize;

        private string _titleText = "Factory Game Co";

        private TextBoxRenderer _buttonTextBoxRenderer;
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
            //CalculateLayout();
        }

        private void LoadContent(string font_path)
        {
            _buttonTextBoxRenderer = new TextBoxRenderer(font_path);
            _titleTextRenderer = new TextRenderer(font_path);

            

            _buttons = new List<MenuButton>
            {
                new MenuButton("Continue", _buttonTextBoxRenderer, Input.MseButton.Left),
                new MenuButton("New Game", _buttonTextBoxRenderer, Input.MseButton.Left),
                new MenuButton("Load", _buttonTextBoxRenderer, Input.MseButton.Left),
                new MenuButton("Settings", _buttonTextBoxRenderer, Input.MseButton.Left),
                new MenuButton("Quit", _buttonTextBoxRenderer, Input.MseButton.Left),
            };

            //CalculateLayout();
        }

        //private void CalculateLayout()
        //{
        //    Vector2<float> startPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.Center);
            
            
           

        //    float padding = 30;
        //    Vector2<float> totalPosMovement = startPos;

        //    foreach (var button in _buttons)
        //    {
        //        Box box = new Box(totalPosMovement, new Vector2<float>(0,0));
        //        button.Layout(box);
                
        //    }
            
        //}

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
            _titleTextRenderer.Draw(_titleText, titlePos, 40);

            //const float buttonPadding = 30;
            //float totalButtonHeight = 0;

            //foreach (MenuButton button in _buttons)
            //{
            //    button.Draw();
            //}

            Vector2<float> buttonPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.Center);

            _buttons[0].Draw(buttonPos, 26, 30);
        }


    }
}
 