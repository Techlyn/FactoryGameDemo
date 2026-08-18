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

        public Box Box { get; private set; }

        public TextBoxRenderer(string resource_path) : base(resource_path)
        {
            FONT = Raylib.LoadFontEx(resource_path, 32, null, 0);
            Raylib.SetTextureFilter(FONT.Texture, TextureFilter.Point);
            Box = new Box(new Vector2<float>(0, 0), new Vector2<float>(0, 0));
           
        }

        public override void Draw(string text, Vector2<float> pos, float size,float padding, float spacing = 1, Color? color = null, Color? bgColor = null, bool margin = false)
        {
            Core.Vector2<float> position = pos;
            Core.Vector2<float> boxSize = Measure(text, size, spacing) + padding;
            position-= boxSize / 2;
            Box = new Box(position, boxSize);
            BoxRenderer.DrawBoxFilled(Box, bgColor ?? Color.Red);
            BoxRenderer.DrawBoxLine(Box, color ?? Color.Black);
            position += padding / 2;
            Raylib.DrawTextEx(FONT, text, new Vector2(position.X, position.Y), size, spacing, color ?? Color.Black);
        }

        
    }
}
