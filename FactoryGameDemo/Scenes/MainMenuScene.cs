using FactoryGameDemo.Render;
using FactoryGameDemo.Utility;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using FactoryGameDemo.Core;
using System.Drawing;

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
        }

        //private void CalculateLayout()
        //{

        //    const float buttonPadding = 30;
        //    float totalButtonsHeight = 0;
        //    List<Vector2<float>> buttonSizes = new List<Vector2<float>>();
        //    foreach (var btn in _buttons)
        //    {
        //        var size = TextRenderer.Measure(btn.Text, btn.Font);
        //        buttonSizes.Add(size);
        //        totalButtonsHeight += size.Y + buttonPadding;
        //    }
        //    totalButtonsHeight -= buttonPadding;

        //    Vector2<float> startingPos = LayoutHelper.GetPosition(LayoutHelper.Anchor.Center);
        //    float startY = startingPos.Y - (totalButtonsHeight / 2);

        //    for (int i = 0; i < _buttons.Count; i++)
        //    {
        //        Vector2<float> textSize = buttonSizes[i];

        //        Vector2<float> buttonPos = new Vector2<float>(startingPos.X - (textSize.X / 2), startY);
        //        _buttons[i].SetLayout(buttonPos, textSize);
        //        startY += textSize.Y + buttonPadding;
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
        }


    }
}
 