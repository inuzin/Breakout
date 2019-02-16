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
    public class Block
    {
        Texture2D block;
        public List<Rectangle> blocksrect = new List<Rectangle>();
        List<Vector2> blocks = new List<Vector2>();
        int columns = 10, rows = 5, totalblocks;
        int x, y;

        public void LoadContent(ContentManager Content)
        {
            block = Content.Load<Texture2D>("Block");

            totalblocks = columns * rows;

            

            
        }

        public void Update()
        {

            AssignBlocks();

            //Load the blocks rectangle in relation to the total blocks count
            //Carrega o retangulo dos blocos de acordo com o total de blocos criados

            for (int i = 0; i <= totalblocks; i++)
            {
                blocksrect.Add(new Rectangle((int)blocks[i].X, (int)blocks[i].Y, block.Width, block.Height));
            }

        }

        public int GetTotalBlocks()
        {
            return totalblocks;
        }

        public int SetTotalBlocks(int a)
        {
            return totalblocks -= a;
        }

        public void AssignBlocks()
        {
            for (int a = 0; a <= rows; a++)
            {
                for (int b = 0; b <= columns; b++)
                {
                    blocks.Add(new Vector2(200 + x, 50 + y));

                    x += (int)block.Width;
                }

                x = 0;
                y += (int)block.Height;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            for(int i = 0; i <= totalblocks; i++)
            {
                batch.Draw(block, blocksrect[i], Color.White);
            }

        }
    }
}
