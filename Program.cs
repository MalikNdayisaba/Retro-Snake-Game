using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace Retro_Snake_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var gridDimension = new Coord(60, 20);
            var snakePos = new Coord(10, 1);
            var rand = new Random();
            var applePos = GenerateApple(rand, gridDimension, snakePos, new List<Coord>());
            var movementDirection = Direction.Down;
            var pendingDirection = movementDirection;
            var frameDelay = 100; // milliseconds
            var score = 0;

            var snakePosHistory = new List<Coord>();
            var tailLength = 1;

            var stopwatch = new Stopwatch();

            while (true)
            {
               
                movementDirection = pendingDirection;
                snakePos = new Coord(snakePos.X, snakePos.Y); 
                snakePos.ApplyMovementDirection(movementDirection);

               
                var buffer = new StringBuilder();
                buffer.AppendFormat("Score: {0}\r\n", score);

                for (int y = 0; y < gridDimension.Y; y++)
                {
                    for (int x = 0; x < gridDimension.X; x++)
                    {
                        var currentCoord = new Coord(x, y);
                        if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                            buffer.Append("■");
                        else if (applePos.Equals(currentCoord))
                            buffer.Append("a");
                        else if (x == 0 || y == 0 || x == gridDimension.X - 1 || y == gridDimension.Y - 1)
                            buffer.Append("+");
                        else
                            buffer.Append(" ");
                    }
                    buffer.Append("\r\n");
                }

                SetCursorPosition(0, 0);
                Write(buffer.ToString());

                // Eat apple
                if (snakePos.Equals(applePos))
                {
                    tailLength++;
                    score++;
                    applePos = GenerateApple(rand, gridDimension, snakePos, snakePosHistory);
                }
            
                else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimension.X - 1 || snakePos.Y == gridDimension.Y - 1 || snakePosHistory.Contains(snakePos))
                {
                    
                    score = 0;
                    tailLength = 1;
                    snakePos = new Coord(10, 1);
                    snakePosHistory.Clear();
                    movementDirection = Direction.Down;
                    pendingDirection = movementDirection;
                    applePos = GenerateApple(rand, gridDimension, snakePos, snakePosHistory);
                    continue;
                }

                
                snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
                if (snakePosHistory.Count > tailLength)
                    snakePosHistory.RemoveAt(0);

                // Frame timing and input handling
                stopwatch.Restart();
                while (stopwatch.ElapsedMilliseconds < frameDelay)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        var newDir = movementDirection;
                        switch (key)
                        {
                            case ConsoleKey.LeftArrow:
                                newDir = Direction.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                newDir = Direction.Right;
                                break;
                            case ConsoleKey.UpArrow:
                                newDir = Direction.Up;
                                break;
                            case ConsoleKey.DownArrow:
                                newDir = Direction.Down;
                                break;
                        }

                      
                        if (!IsOpposite(newDir, movementDirection))
                        {
                            pendingDirection = newDir;
                        }
                    }
                }
            }
        }

        private static bool IsOpposite(Direction a, Direction b)
        {
            return (a == Direction.Left && b == Direction.Right)
                || (a == Direction.Right && b == Direction.Left)
                || (a == Direction.Up && b == Direction.Down)
                || (a == Direction.Down && b == Direction.Up);
        }

        private static Coord GenerateApple(Random rand, Coord grid, Coord head, List<Coord> snake)
        {
            Coord pos;
            do
            {
                pos = new Coord(rand.Next(1, grid.X - 1), rand.Next(1, grid.Y - 1));
            } while (pos.Equals(head) || snake.Contains(pos));
            return pos;
        }
    }
}