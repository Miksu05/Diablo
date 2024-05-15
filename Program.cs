using Raylib_cs;
using System.Numerics;

namespace Diablo
{
    class Program
    {
        const int GameFPS = 60;
        const int ScreenWidth = 512;
        const int ScreenHeight = 512;

        class Player
        {
            public Vector2 position;
            private float playerSpeed;

            public Player(float deltaTime)
            {
                playerSpeed = 120 * deltaTime;
                position = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
            }

            public void Update()
            {
                if (Raylib.IsKeyDown(KeyboardKey.Right)) position.X += playerSpeed;
                if (Raylib.IsKeyDown(KeyboardKey.Left)) position.X -= playerSpeed;
                if (Raylib.IsKeyDown(KeyboardKey.Down)) position.Y += playerSpeed;
                if (Raylib.IsKeyDown(KeyboardKey.Up)) position.Y -= playerSpeed;
            }


            static void Main(string[] args)
            {
                MainWindow.RunMainMenu();


                Raylib.SetTargetFPS(GameFPS);
                Player player = new Player(1.0f / GameFPS);
            }

        }
    }
}
