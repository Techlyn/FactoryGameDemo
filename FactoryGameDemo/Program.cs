using System;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using FactoryGameDemo.Scenes;
using Raylib_cs;


namespace FactoryGameDemo;
internal static class Program
{
    
    public static void Main(string[] args)
    {
     
        FactoryGameWelcomePageRevised();
    }


    static void FactoryGameWelcomePageRevised()
    {
        Raylib.InitWindow(Core.Globals.WINDOW_WIDTH, Core.Globals.WINDOW_HEIGHT, "Hello Raylib");
        string font_path = "resources/arial.ttf";
        MainMenuScene _mainMenu = new MainMenuScene(font_path);
        while (!Raylib.WindowShouldClose())
        {
            _mainMenu.Update();
            Raylib.BeginDrawing();
            _mainMenu.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
    


    

    





}