using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Paddle paddle = new Paddle();
        Ball ball = new Ball();
        Block block = new Block();

        int Score;

        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddle.LoadContent(Content);
            ball.LoadContent(Content);
            block.LoadContent(Content);

            font = Content.Load<SpriteFont>("Scorefont");
        }        

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            paddle.Update();
            ball.Update();
            block.Update();
            Collision();

            base.Update(gameTime);
        }

        public void Collision()
        {
            if (ball.ballrect.Intersects(paddle.paddlerect))
            {
                ball.SetBallSpeedY(-2);
            }

            
            for (int i = 0; i <= block.GetTotalBlocks(); i++)
            {
                if (ball.ballrect.Intersects(block.blocksrect[i]))
                {
                    if (ball.GetBallPosY() <= block.blocksrect[i].Top)
                    {
                        ball.SetBallSpeedY(-2);
                    }

                    if (ball.GetBallPosY() <= block.blocksrect[i].Bottom)
                    {
                    ball.SetBallSpeedY(2); 
                    }

                    if (ball.GetBallPosX() <= block.blocksrect[i].Right)
                    {
                        ball.SetBallSpeedX(2);
                    }

                    if (ball.GetBallPosX() <= block.blocksrect[i].Left)
                    {
                        ball.SetBallSpeedX(-2);
                    }

                    //Remove block
                    block.blocksrect.RemoveAt(i);
                    block.SetTotalBlocks(1);
                    Score += 10;
                }
            }
            
        }

        public void Reset()
        {
            //Return ball to initial position
            //Retorna bola para pos inicial
            ball.SetBallPos(new Vector2(400, 250));

            //Update total blocks
            //Atualiza total de blocos
            block.SetTotalBlocks(block.GetColumns() * block.GetRows());

            //Rebuild blocks
            //Reconstroi blocos
            block.AssignBlocks();

            //Reset Score
            Score = 0;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            block.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Score: " + Score, new Vector2(640, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
