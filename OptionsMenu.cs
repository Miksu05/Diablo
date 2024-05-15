using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Diablo.MainWindow;


namespace Diablo
{
    public class OptionsMenu
    {
        // Window dimensions
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Button and slider dimensions
        const int buttonWidth = 200;
        const int buttonHeight = 50;
        const int sliderWidth = 200;
        const int sliderHeight = 20;

        // State variables
        static bool isMusicOn = true;
        static float musicVolume = 0.5f;
        static bool isGodMode = false;

        public static void RunOptionsMenu()
        {
            while (MainWindow.currentState == GameState.OptionsMenu && !Raylib.WindowShouldClose())
            {
                UpdateOptionsMenu();
                DrawOptionsMenu();
            }
        }

        static void UpdateOptionsMenu()
        {
            Vector2 mousePosition = Raylib.GetMousePosition();

            // Check if Music On/Off button is clicked
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 100, buttonWidth, buttonHeight))
                {
                    isMusicOn = !isMusicOn;
                    Console.WriteLine($"Music turned {(isMusicOn ? "On" : "Off")}");
                }

                // Check if God Mode button is clicked
                if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 200, buttonWidth, buttonHeight))
                {
                    isGodMode = !isGodMode;
                    Console.WriteLine($"God Mode turned {(isGodMode ? "On" : "Off")}");
                }

                // Check if Back button is clicked
                if (CheckButtonClicked(mousePosition, screenWidth / 2 - buttonWidth / 2, 350, buttonWidth, buttonHeight))
                {
                    Console.WriteLine("Back to Main Menu");
                    MainWindow.currentState = GameState.MainMenu;
                }
            }

            // Check if the music volume slider is adjusted
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                if (CheckButtonClicked(mousePosition, screenWidth / 2 - sliderWidth / 2, 150, sliderWidth, sliderHeight))
                {
                    musicVolume = (mousePosition.X - (screenWidth / 2 - sliderWidth / 2)) / (float)sliderWidth;
                    musicVolume = Math.Clamp(musicVolume, 0f, 1f);
                    Console.WriteLine($"Music volume set to {musicVolume * 100}%");
                }
            }
        }

        static void DrawOptionsMenu()
        {
            // Start drawing
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Draw Music On/Off button
            DrawButton(screenWidth / 2 - buttonWidth / 2, 100, buttonWidth, buttonHeight, $"Music: {(isMusicOn ? "On" : "Off")}", Color.LightGray);

            // Draw Music Volume slider
            DrawSlider(screenWidth / 2 - sliderWidth / 2, 150, sliderWidth, sliderHeight, musicVolume);

            // Draw God Mode button
            DrawButton(screenWidth / 2 - buttonWidth / 2, 200, buttonWidth, buttonHeight, $"God Mode: {(isGodMode ? "On" : "Off")}", Color.LightGray);

            // Draw Back button
            DrawButton(screenWidth / 2 - buttonWidth / 2, 350, buttonWidth, buttonHeight, "Back", Color.LightGray);

            // End drawing
            Raylib.EndDrawing();
        }

        static void DrawButton(int x, int y, int width, int height, string text, Color color)
        {
            Raylib.DrawRectangle(x, y, width, height, color);
            Raylib.DrawText(text, x + (width / 2 - Raylib.MeasureText(text, 20) / 2), y + (height / 2 - 10), 20, Color.Black);
        }

        static void DrawSlider(int x, int y, int width, int height, float value)
        {
            Raylib.DrawRectangle(x, y, width, height, Color.LightGray);
            Raylib.DrawRectangle(x, y, (int)(width * value), height, Color.DarkGray);
        }

        static bool CheckButtonClicked(Vector2 mousePosition, int x, int y, int width, int height)
        {
            return mousePosition.X >= x && mousePosition.X <= x + width &&
                   mousePosition.Y >= y && mousePosition.Y <= y + height;
        }
    }
}