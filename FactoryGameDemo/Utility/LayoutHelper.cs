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

    public static Vector2<float> GetPosition(Anchor anchor)
    {
        Vector2<float> halfWindow = new Vector2<float>(_windowSize.X, _windowSize.Y)/2;

        return anchor switch
        {
            Anchor.TopLeft => new Vector2<float>(0, 0),
            Anchor.TopCenter => new Vector2<float>(halfWindow.X, 0),
            Anchor.TopRight => new Vector2<float>(_windowSize.X, 0),

            Anchor.LeftCenter => new Vector2<float>(0, halfWindow.Y),
            Anchor.Center => halfWindow,
            Anchor.RightCenter => new Vector2<float>(_windowSize.X, halfWindow.Y),

            Anchor.BottomLeft => new Vector2<float>(0, _windowSize.Y),
            Anchor.BottomCenter => new Vector2<float>(halfWindow.X, _windowSize.Y),
            Anchor.BottomRight => new Vector2<float>(_windowSize.X, _windowSize.Y),
            _ => throw new ArgumentOutOfRangeException(nameof(anchor), anchor, null)
        };
    }
}
