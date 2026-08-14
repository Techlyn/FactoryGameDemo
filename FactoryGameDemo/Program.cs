using System;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Raylib_cs;


internal static class Program
{

    private const int WINDOW_WIDTH = 1280;
    private const int WINDOW_HEIGHT = 720;

    private const float MARGIN_PERCENT = 0.10f;
    private const float TEXT_SIZE = 20.0f;
    private const float SPACE_SIZE = 1.0f;

    private static Color DEFAULT_TEXT_COLOR => Color.Black;
    private static Color BACKGROUND_COLOR => Color.White;

    public static Vector2 Margin() => new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT) * MARGIN_PERCENT;

    public static Vector2 Center(Vector2 textSize) => new Vector2(WINDOW_WIDTH/2, WINDOW_HEIGHT/2) - (textSize/2);
    public static Vector2 TopLeft() => Margin();
    public static Vector2 TopCenter(Vector2 textSize) => new Vector2((WINDOW_WIDTH / 2) - (textSize.X/2), Margin().Y);
    public static Vector2 TopRight(Vector2 textSize) => new Vector2(WINDOW_WIDTH - textSize.X - Margin().X, Margin().Y);
    public static Vector2 LeftCenter(Vector2 textSize) => new Vector2(Margin().X, (WINDOW_HEIGHT / 2) - (textSize.Y / 2));
    public static Vector2 RightCenter(Vector2 textSize) => new Vector2(WINDOW_WIDTH - Margin().X - textSize.X, (WINDOW_HEIGHT / 2) - (textSize.Y / 2));
    public static Vector2 BottomCenter(Vector2 textSize) => new Vector2((WINDOW_WIDTH / 2) - (textSize.X / 2), WINDOW_HEIGHT - Margin().Y - textSize.Y);
    public static Vector2 LeftBottom(Vector2 textSize) => new Vector2(Margin().X, (WINDOW_HEIGHT - Margin().Y - textSize.Y));
    public static Vector2 RightBottom(Vector2 textSize) => new Vector2(WINDOW_WIDTH - Margin().X - textSize.X, WINDOW_HEIGHT - Margin().Y - textSize.Y);
    

    public static Vector2 TextSize(Font font, string text, float textSize = TEXT_SIZE, float spacing = SPACE_SIZE) => Raylib.MeasureTextEx(font, text, textSize, spacing);

    public static void DrawText(Font font, string text, Vector2 pos, float fontSize = TEXT_SIZE, float spacing = SPACE_SIZE, Color? color = null)
    {
        Color drawColor = color ?? DEFAULT_TEXT_COLOR;
        Raylib.DrawTextEx(font, text, pos, fontSize, spacing, drawColor);
    }
    
    public static void Main(string[] args)
    {
        //RaylibWindow();
        FactoryGameWelcomePage();
    }

    


    static void FactoryGameWelcomePage()
    {
        Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Hello Raylib");
        Font font = Raylib.LoadFont("Resources/arial.ttf");
        
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(BACKGROUND_COLOR);
            Title(font);
            Options(font);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }

    private static void Title(Font font)
    {
        string title = "Factory Game Co.";
        float textSize = 40;
        DrawText(font, title, TopLeft(), textSize);
    }

    private static void Options(Font font)
    {
        Vector2 boxPos = new Vector2(Margin().X, WINDOW_HEIGHT / 3);
        Vector2 boxSize = new Vector2(WINDOW_WIDTH / 4, WINDOW_HEIGHT - Margin().X - (WINDOW_HEIGHT / 3));
        Raylib.DrawRectangleLines((int)boxPos.X, (int)boxPos.Y, (int)boxSize.X, (int)boxSize.Y + 20, Color.Black);
        Continue(font, boxPos, boxSize);
        NewGame(font, boxPos, boxSize);
        Load(font, boxPos, boxSize);
        Settings(font, boxPos, boxSize);
        Quit(font, boxPos, boxSize);
    }

    private static Vector2 textBoxInitPos(Vector2 boxPos) => new Vector2(boxPos.X + 20, boxPos.Y + 20);
    private static Vector2 textBoxInitSize(Vector2 boxSize) => new Vector2(boxSize.X - 20 * 2, boxSize.Y / 5 - 20);

    private static Vector2 textPos(Font font, string text, Vector2 boxPos, Vector2 boxSize, float fontSize) => 
        new Vector2(boxPos.X + (boxSize.X/2) - (TextSize(font, text, fontSize).X/2), boxPos.Y + (boxSize.Y / 2) - (TextSize(font, text, fontSize).Y/2));

    private static void Continue(Font font, Vector2 boxPos, Vector2 boxSize)
    {
        Vector2 textBoxPos = textBoxInitPos(boxPos);
        Vector2 textBoxSize = textBoxInitSize(boxSize);
        Raylib.DrawRectangleLines((int)textBoxPos.X, (int)textBoxPos.Y, (int)textBoxSize.X, (int)textBoxSize.Y, Color.Black);
        string text = "Continue";
        float fontSize = textBoxSize.Y - 20;
        Vector2 newTextPos = textPos(font, text, textBoxPos, textBoxSize, fontSize);
        DrawText(font, text, newTextPos, fontSize);
    }

    private static void NewGame(Font font, Vector2 boxPos, Vector2 boxSize)
    {
        Vector2 textBoxPos = textBoxInitPos(boxPos);
        textBoxPos.Y += boxSize.Y / 5;
        Vector2 textBoxSize = textBoxInitSize(boxSize);
        Raylib.DrawRectangleLines((int)textBoxPos.X, (int)textBoxPos.Y, (int)textBoxSize.X, (int)textBoxSize.Y, Color.Black);
        string text = "New Game";
        float fontSize = textBoxSize.Y - 20;
        Vector2 newTextPos = textPos(font, text, textBoxPos, textBoxSize, fontSize);
        DrawText(font, text, newTextPos, fontSize);
    }

    private static void Load(Font font, Vector2 boxPos, Vector2 boxSize)
    {
        Vector2 textBoxPos = textBoxInitPos(boxPos);
        textBoxPos.Y += 2 * (boxSize.Y / 5);
        Vector2 textBoxSize = textBoxInitSize(boxSize);
        Raylib.DrawRectangleLines((int)textBoxPos.X, (int)textBoxPos.Y, (int)textBoxSize.X, (int)textBoxSize.Y, Color.Black);
        string text = "Load";
        float fontSize = textBoxSize.Y - 20;
        Vector2 newTextPos = textPos(font, text, textBoxPos, textBoxSize, fontSize);
        DrawText(font, text, newTextPos, fontSize);
    }

    private static void Settings(Font font, Vector2 boxPos, Vector2 boxSize)
    {
        int pos = 3;
        Vector2 textBoxPos = textBoxInitPos(boxPos);
        textBoxPos.Y += pos * (boxSize.Y / 5);
        Vector2 textBoxSize = textBoxInitSize(boxSize);
        Raylib.DrawRectangleLines((int)textBoxPos.X, (int)textBoxPos.Y, (int)textBoxSize.X, (int)textBoxSize.Y, Color.Black);
        string text = "Setting";
        float fontSize = textBoxSize.Y - 20;
        Vector2 newTextPos = textPos(font, text, textBoxPos, textBoxSize, fontSize);
        DrawText(font, text, newTextPos, fontSize);
    }

    private static void Quit(Font font, Vector2 boxPos, Vector2 boxSize)
    {
        int pos = 4;
        Vector2 textBoxPos = textBoxInitPos(boxPos);
        textBoxPos.Y += pos * (boxSize.Y / 5);
        Vector2 textBoxSize = textBoxInitSize(boxSize);
        Raylib.DrawRectangleLines((int)textBoxPos.X, (int)textBoxPos.Y, (int)textBoxSize.X, (int)textBoxSize.Y, Color.Black);
        string text = "Quit";
        float fontSize = textBoxSize.Y - 20;
        Vector2 newTextPos = textPos(font, text, textBoxPos, textBoxSize, fontSize);
        DrawText(font, text, newTextPos, fontSize);
    }





}