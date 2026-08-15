using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactoryGameDemo.Utility
{
    public class Box
    {
        public Core.Vector2<float> Position { get; set; }
        public Core.Vector2<float> Size { get; set; }

        public Box(Core.Vector2<float> pos, Core.Vector2<float> size)
        {
            Position = pos;
            Size = size;
        }

    }
}
