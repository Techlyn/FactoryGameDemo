using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace FactoryGameDemo.Utility
{
    public static class Collisions
    {
        public static bool BoxContainsMouse(Box box, Core.Vector2<float> mousePosition)
        {
            Core.Vector2<float> mousePos = mousePosition;
            Core.Vector2<float> corner = box.Position;
            Core.Vector2<float> opCorner = box.Position + box.Size;

            if(mousePos.X >= corner.X && mousePos.X <= opCorner.X)
            {
                if(mousePos.Y >= corner.Y && mousePos.Y <= opCorner.Y)
                {
                    return true;
                }
            }
            return false;
        }
       
    }
}
