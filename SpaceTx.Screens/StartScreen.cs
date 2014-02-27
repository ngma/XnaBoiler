using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceTx.Screens
{
    public class Screen
    {
        private Texture2D mSpriteTexture;
        private Texture2D mushroom;
        private List<Vector2> mushroomVector2;
        private int h = 0;
        private int w = 0;
        public Screen(GraphicsDeviceManager gdm)
        {
            //gdm.GraphicsDevice.Clear(Color.GreenYellow);
            mushroomVector2 = new List<Vector2>();
            h = (gdm.GraphicsDevice.Viewport.Height - 480) / 2;
            w = (gdm.GraphicsDevice.Viewport.Width - 640) / 2;
        }

        /// <summary>
        /// Sleeps for 10 seconds, adds new vector coords for progress bar..
        /// </summary>
        public void LoadResources()
        {
            mushroomVector2.Add(new Vector2(255 + w, 328 + h));
            ThreadStart threadStarter = delegate
            {
                for (int i = 0; i < 6; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    int lwidth = (int)mushroomVector2.Last().X + 20;
                    int lheight = (int) mushroomVector2.Last().Y;
                    mushroomVector2.Add(new Vector2(lwidth, lheight));
                }
            };
            Thread loadingThread = new Thread(threadStarter);
            loadingThread.Start();
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, new Rectangle(w, h, 640, 480), Color.White);
            mushroomVector2.ForEach(x=>theSpriteBatch.Draw(mushroom, x, Color.White));
        }

        public void LoadContent(GraphicsDevice gd)
        {
            System.IO.Stream stream = TitleContainer.OpenStream("Content/StartScreen.png");
            mSpriteTexture = Texture2D.FromStream(gd, stream);
            stream = TitleContainer.OpenStream("Content/mushroom.png");
            mushroom = Texture2D.FromStream(gd, stream);
            LoadResources();
        }
    }
}
