using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Diablo
{
    public enum GameState
    {
        MainMenu,
        OptionsMenu,
        Game
        // Add other states as needed
    }

    public class MainWindow
        {
            // Window dimensions
            const int screenWidth = 800;
            const int screenHeight = 450;

            // Button dimensions
            const int buttonWidth = 200;
            const int buttonHeight = 50;

            public static GameState currentState = GameState.MainMenu;



            public static void RunMainMenu()
            {
                // Initialize the window
                Raylib.InitWindow(screenWidth, screenHeight, "Main Menu");

                // Main loop
                while (!Raylib.WindowShouldClose())
                {
                    switch (currentState)
                    {
                        case GameState.MainMenu:
                            UpdateMainMenu();
                            DrawMainMenu();
                            break;
                        case GameState.OptionsMenu:
                            OptionsMenu.RunOptionsMenu();
                            break;
                        // Add other cases for different states
                }
                }

                // Close the window
                Raylib.CloseWindow();
            }

        static void UpdateMainMenu()
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    Vector2 mousePosition = Raylib.GetMousePosition();

                    // Quit button
                    if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 300, buttonWidth, buttonHeight))
                    {
                        Raylib.CloseWindow();
                    }

                    // Options button
                    if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 200, buttonWidth, buttonHeight))
                    {
                        currentState = GameState.OptionsMenu;
                    }

                    // Start button
                    if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 100, buttonWidth, buttonHeight))
                    {
                        
                    }
            }
            }

            static void DrawMainMenu()
            {
                // Start drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                // Draw buttons
                DrawButton(screenWidth / 2 - buttonWidth / 2, 100, buttonWidth, buttonHeight, "Start", Color.LightGray);
                DrawButton(screenWidth / 2 - buttonWidth / 2, 200, buttonWidth, buttonHeight, "Options", Color.LightGray);
                DrawButton(screenWidth / 2 - buttonWidth / 2, 300, buttonWidth, buttonHeight, "Quit", Color.LightGray);

                // End drawing
                Raylib.EndDrawing();
            }

            static void DrawButton(int x, int y, int width, int height, string text, Color color)
            {
                Raylib.DrawRectangle(x, y, width, height, color);
                Raylib.DrawText(text, x + (width / 2 - Raylib.MeasureText(text, 20) / 2), y + (height / 2 - 10), 20, Color.Black);
            }

            static bool CheckButtonClicked(Vector2 mousePosition, int x, int y, int width, int height)
            {
                return mousePosition.X >= x && mousePosition.X <= x + width &&
                       mousePosition.Y >= y && mousePosition.Y <= y + height;
            }
        }
}
