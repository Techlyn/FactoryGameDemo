using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace FactoryGameDemo.Input
{
    public enum MseButton
    {
        Undefined,
        Left,
        Right,
        Middle,
    }
    public static class Input
    {

        public static Core.Vector2<int> MousePosition()
        {
            int X = Raylib.GetMouseX();
            int Y = Raylib.GetMouseY();

            return new Core.Vector2<int>(X, Y);
        }

        public static MseButton MousePressed()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                return MseButton.Left;
            }
            if (Raylib.IsMouseButtonPressed(MouseButton.Right))
            {
                return MseButton.Right;
            }
            if (Raylib.IsMouseButtonPressed(MouseButton.Middle))
            {
                return MseButton.Middle;
            }
            return MseButton.Undefined;
        }

        public static MseButton MouseReleased()
        {
            if (Raylib.IsMouseButtonReleased(MouseButton.Left))
            {
                return MseButton.Left;
            }
            if (Raylib.IsMouseButtonReleased(MouseButton.Right))
            {
                return MseButton.Right;
            }
            if (Raylib.IsMouseButtonReleased(MouseButton.Middle))
            {
                return MseButton.Middle;
            }
            return MseButton.Undefined;
        }

    }
}
