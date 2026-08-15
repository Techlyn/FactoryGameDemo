using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using FactoryGameDemo.Core;

namespace FactoryGameDemo.Utility;

public static class LayoutHelper
{
    private static readonly Vector2<float> _margin = new Vector2<float>(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT)* Globals.MARGIN_PERCENT;
    private static readonly Vector2<float> _windowSize = new Vector2<float>(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT);
    public static Vector2<float> Margin => _margin;


    public enum Anchor
    {
        TopLeft, TopCenter, TopRight,
        LeftCenter, Center, RightCenter,
        BottomLeft, BottomCenter, BottomRight,
    }

    public static Vector2<float> GetPosition(Vector2<float> textSize, Anchor anchor)
    {
        Vector2<float> halfSize = textSize / 2;
        Vector2<float> halfWindow = new Vector2<float>(_windowSize.X, _windowSize.Y)/2;

        return anchor switch
        {
            Anchor.TopLeft => _margin,
            Anchor.TopCenter => new Vector2<float>(halfWindow.X - halfSize.X, _margin.Y),
            Anchor.TopRight => new Vector2<float>(_windowSize.X - textSize.X - _margin.X, _margin.Y),

            Anchor.LeftCenter => new Vector2<float>(_margin.X, halfWindow.Y - halfSize.Y),
            Anchor.Center => halfWindow - halfSize,
            Anchor.RightCenter => new Vector2<float>(_windowSize.X - _margin.X - textSize.X, halfWindow.Y - halfSize.Y),

            Anchor.BottomLeft => new Vector2<float>(_margin.X, _windowSize.Y - _margin.Y - textSize.Y),
            Anchor.BottomCenter => new Vector2<float>(halfWindow.X - _margin.X - textSize.X, _windowSize.Y - _margin.Y - textSize.Y),
            Anchor.BottomRight => new Vector2<float>(_windowSize.X - _margin.X - textSize.X, _windowSize.Y - _margin.Y - textSize.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(anchor), anchor, null)
        };
    }
}
