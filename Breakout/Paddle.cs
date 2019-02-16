using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Breakout
{
    public class Paddle
    {
        Texture2D paddle;
        Vector2 paddlepos = new Vector2(300,530);
        public Rectangle paddlerect;
        int Boundleft = 0, Boundright = 605;

        public void LoadContent(ContentManager Content)
        {
            paddle = Content.Load<Texture2D>("paddle");
        }

        public void Update()
        {          

            //Load the paddle rectangle
            //Carrega o retangulo da paddle
            paddlerect = new Rectangle((int)paddlepos.X, (int)paddlepos.Y, paddle.Width, paddle.Height);

            Input();
            Bounds();
        }

        public void Input()
        {
            //Controls the player input of the paddle
            //Controla o input do jogador com a paddle

            KeyboardState keyboard = Keyboard.GetState();

            if(keyboard.IsKeyDown(Keys.Right))
            {
                paddlepos.X += 4;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                paddlepos.X -= 4;
            }
        }

        public void Bounds()
        {
            //Limit the windows bounds for the paddle
            //Delimita os limites da tela para a paddle

            if(paddlepos.X <= Boundleft)
            {
                paddlepos.X = Boundleft;
            }

            if (paddlepos.X >= Boundright)
            {
                paddlepos.X = Boundright;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(paddle, paddlerect, Color.White);
        }
    }
}
