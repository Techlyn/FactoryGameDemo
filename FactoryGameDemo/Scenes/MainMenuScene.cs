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
        private IFont _fontTitle;
        private IFont _fontButton;
        private List<MenuButton> _buttons;


        public MainMenuScene()
        {
            _windowSize = new Vector2<float>(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT);

            LoadContent();
            CalculateLayout();
        }

        private void LoadContent()
        {
            _fontTitle = FontSettings.Create("resources/arial.ttf", size: 40, color: Raylib_cs.Color.Black);
            _fontButton = FontSettings.Create("resources/arial.ttf", size: 28, color: Raylib_cs.Color.Black);

            _buttons = new List<MenuButton>
            {
                new MenuButton("Continue", _fontButton, Input.MseButton.Left),
                new MenuButton("New Game", _fontButton, Input.MseButton.Left),
                new MenuButton("Load", _fontButton, Input.MseButton.Left),
                new MenuButton("Settings", _fontButton, Input.MseButton.Left),
                new MenuButton("Quit", _fontButton, Input.MseButton.Left),
            };
        }

        private void CalculateLayout()
        {
            Vector2<float> titleSize = TextRenderer.Measure(_titleText, _fontTitle);
           

            const float buttonPadding = 30;
            float totalButtonsHeight = 0;
            List<Vector2<float>> buttonSizes = new List<Vector2<float>>();
            foreach (var btn in _buttons)
            {
                var size = TextRenderer.Measure(btn.Text, btn.Font);
                buttonSizes.Add(size);
                totalButtonsHeight += size.Y + buttonPadding;
            }
            totalButtonsHeight -= buttonPadding;

            Vector2<float> startingPos = LayoutHelper.GetPosition(titleSize, LayoutHelper.Anchor.Center);
            float startY = startingPos.Y - (totalButtonsHeight / 2);

            for (int i = 0; i < _buttons.Count; i++)
            {
                Vector2<float> textSize = buttonSizes[i];

                Vector2<float> buttonPos = new Vector2<float>(startingPos.X - (textSize.X / 2), startY);
                _buttons[i].SetLayout(buttonPos, textSize);
                startY += textSize.Y + buttonPadding;
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

            Vector2<float> titleSize = TextRenderer.Measure(_titleText, _fontTitle);
            Vector2<float> titlePos = LayoutHelper.GetPosition(titleSize, LayoutHelper.Anchor.TopCenter);
            TextRenderer.Draw(_titleText, _fontButton, titlePos);

            foreach (MenuButton button in _buttons)
            {
                button.Draw();
            }
        }


    }
}
