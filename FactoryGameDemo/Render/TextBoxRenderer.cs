using FactoryGameDemo.Core;
using FactoryGameDemo.Utility;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
namespace FactoryGameDemo.Render
{
    public class TextBoxRenderer : TextRenderer
    {
        public TextBoxRenderer(string resource_path) : base(resource_path)
        {
            FONT = Raylib.LoadFont(resource_path);
        }

        public override void Draw(string text, Vector2<float> pos, float size,float padding, float spacing = 1, Color? color = null, bool margin = false)
        {
            Core.Vector2<float> position = pos;
            Core.Vector2<float> boxSize = Measure(text, size, spacing) + padding;
            position.X -= boxSize.X / 2;
            Box box = new Box(position, boxSize);
            BoxRenderer.DrawBoxLine(box, color ?? Color.Black);
            position += padding / 2;
            Raylib.DrawTextEx(FONT, text, new Vector2(position.X, position.Y), size, spacing, color ?? Color.Black);
        }
    }
}
