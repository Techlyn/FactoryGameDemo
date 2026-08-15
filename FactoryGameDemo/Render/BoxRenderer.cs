using FactoryGameDemo.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Raylib_cs;
using System.Numerics;
namespace FactoryGameDemo.Render
{
    public static class BoxRenderer
    {
        public static void DrawBoxFilled(Box box, Raylib_cs.Color color)
        {
            Core.Vector2<int> pos = Core.Vector2<float>.ToInt(box.Position);
            Core.Vector2<int> size = Core.Vector2<float>.ToInt(box.Size);
            Raylib.DrawRectangle(pos.X, pos.Y, size.X, size.Y, color);
        }
        public static void DrawBoxLine(Box box, Raylib_cs.Color color)
        {
            Core.Vector2<int> pos = Core.Vector2<float>.ToInt(box.Position);
            Core.Vector2<int> size = Core.Vector2<float>.ToInt(box.Size);
            Raylib.DrawRectangleLines(pos.X, pos.Y, size.X, size.Y, color);
        }
    }
}
