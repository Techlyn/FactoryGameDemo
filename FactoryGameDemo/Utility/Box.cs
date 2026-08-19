using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactoryGameDemo.Utility
{
    public class Box
    {
        private Core.Vector2<float> _position;
        private Core.Vector2<float> _size;

        public Box(Core.Vector2<float>? pos = null, Core.Vector2<float>? size = null)
        {
            _position = pos ?? new Core.Vector2<float>(0, 0);
            _size = size ?? new Core.Vector2<float>(0, 0);
        }

        public Core.Vector2<float> Position { get { return _position; } set { _position.X = value.X; _position.Y = value.Y; } }
        public Core.Vector2<float> Size { get { return _size; } set {  _size.X = value.X; _size.Y = value.Y; }  }
       

    }
}
