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
            ballrect = new Rectangle((int)ballpos.X, (int)ballpos.Y, ball.Width, ball.Height);

            Bounce();
            SetBallSpeedY(ballspeedY);
            SetBallSpeedX(ballspeedX);
        }

        public void Bounce()
        {
            //Start ball movement
            ballpos.X += ballspeedX;
            ballpos.Y += ballspeedY;
         
            //Ball collides with screen bounds and bounce back
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

        public void SetBallPos(Vector2 a)
        {
            ballpos = a;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(ball, ballrect, Color.White);
        }
    }
}
