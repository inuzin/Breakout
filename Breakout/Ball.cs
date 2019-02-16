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
    public class Ball
    {
        Texture2D ball;
        Vector2 ballpos = new Vector2(400,250);
        public Rectangle ballrect;
        int boundtop = 0, boundbottom = 580, boundleft = 0, boundright = 780, ballspeedX = 2, ballspeedY = 2;

        public void LoadContent(ContentManager Content)
        {
            ball = Content.Load<Texture2D>("Ball");
        }

        public void Update()
        {
            //Load the ball rectangle
            //Carrega o retangulo da bola
            ballrect = new Rectangle((int)ballpos.X, (int)ballpos.Y, ball.Width, ball.Height);

            Bounce();
            SetBallSpeedY(ballspeedY);
            SetBallSpeedX(ballspeedX);
        }

        public void Bounce()
        {

            ballpos.X += ballspeedX;
            ballpos.Y += ballspeedY;
         

            if(ballpos.X <= boundleft)
            {
                ballspeedX = -ballspeedX;
            }

            if(ballpos.X >= boundright)
            {
                ballspeedX = -ballspeedX;
            }

            if(ballpos.Y <= boundtop)
            {
                ballspeedY = -ballspeedY;
            }

            if(ballpos.Y >= boundbottom)
            {
                ballspeedY = -ballspeedY;
            }
        }

        public int GetBallSpeedY()
        {
            return ballspeedY;
        }

        public void SetBallSpeedY(int a)
        {
            ballspeedY = a;
        }

        public int GetBallSpeedX()
        {
            return ballspeedX;
        }

        public void SetBallSpeedX(int a)
        {
            ballspeedX = a;
        }

        public float GetBallPosY()
        {
            return ballpos.Y;
        }

        public float GetBallPosX()
        {
            return ballpos.X;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(ball, ballrect, Color.White);
        }
    }
}
