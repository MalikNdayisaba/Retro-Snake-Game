🐍 Retro Snake Game (C# Console)

A classic retro Snake game built using C# and the .NET Console.

This project recreates the traditional Snake gameplay in a text-based console environment using real-time keyboard input, collision detection, and dynamic rendering.

🎮 Features

Console-based game grid

Real-time movement using arrow keys

Growing snake tail when apples are eaten

Score tracking

Random apple spawning

Wall and self-collision detection

Instant game reset on collision

Smooth frame timing using Stopwatch

🕹 Controls
Key	Action
⬅️	Move Left
➡️	Move Right
⬆️	Move Up
⬇️	Move Down
🧠 How It Works
Game Logic

Snake position stored using Coord objects

Tail stored in List<Coord> history

Apple spawns randomly inside the grid

Game updates every frame (~100ms delay)

Collision Detection

Game resets when:

Snake hits the wall

Snake hits itself

Rendering

The game board is drawn using:

■ for snake

a for apple

+ for borders

spaces for empty cells

🛠 Technologies Used

C#

.NET Console

System.Text (StringBuilder)

Stopwatch for timing

Object-Oriented Programming principles

▶️ How to Run
Using Visual Studio

Open the solution/project

Build the project

Run (F5 or Ctrl+F5)

Using .NET CLI
dotnet run

📁 Project Structure
Retro_Snake_Game/
│
├── Program.cs      # Main game loop and logic
├── Coord.cs        # Coordinate handling
├── Direction.cs    # Movement directions

🚀 Possible Improvements

Ideas for future enhancements:

High score saving

Increasing speed over time

Pause feature

Start menu

Sound effects

Multiple difficulty levels

Colored console graphics

Wrap-around walls mode

📸 Preview

Console-style gameplay similar to:

++++++++++++++++++++++++++
+                        +
+        ■■■             +
+            a           +
+                        +
++++++++++++++++++++++++++
Score: 3

📚 Learning Goals

This project demonstrates:

Game loops

Real-time input handling

Collision detection

State management

Working with collections

Console rendering techniques

Great for beginners learning C# game logic fundamentals.
