using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using FactoryGameDemo.Utility;

namespace FactoryGameDemo.Render
{
    public class ButtonRenderer(TextSettings settings) : TextBoxRenderer(settings)
    {
        public override void Init(string text, Core.Vector2<float> position, float font_size, float padding = 0, float spacing = 1, Color? color = null, Color? bgColor = null)
        {
            base.Init(text,position, font_size, padding, spacing, color, bgColor);
        }

        public void ChangeBackgroundColor(Color bgColor) => BackgroundColor = bgColor;

        public Box CollectButtonBox() => Box;

        public void Draw()
        {
            base.Draw();
        }

        
    }
}
