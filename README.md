A simple Breakout clone made in C# with Monogame.

Ball.cs makes the ball bounce around the screen once it detects any screen bounds.

Padle.cs: Receives the player input and moves the paddle.

Block.cs: Creates blocks with the specified number of rows and columns using lists for its position and rectangle.

Game1.cs: Applies the collision to the ball/paddle or ball/blocks and provides a method to reset the ball position/score and blocks count.
