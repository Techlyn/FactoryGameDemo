using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Raylib_cs;
namespace FactoryGameDemo.Render
{
    public static class BackgroundColor
    {
        public static void ClearBackground(Raylib_cs.Color? color = null)
        {
            Raylib.ClearBackground(color ?? Raylib_cs.Color.White);
        }
    }
}
