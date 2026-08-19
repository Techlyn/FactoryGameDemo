using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace FactoryGameDemo.Render
{
    public class TextSettings : IDisposable
    {
        public Raylib_cs.Font FONT { get; }

        public TextSettings(string resource_path)
        {
            FONT = Raylib.LoadFontEx(resource_path, 32, null, 0);
            Raylib.SetTextureFilter(FONT.Texture, TextureFilter.Point);

        }

        public void Dispose() => Raylib.UnloadFont(FONT);
    }
}
