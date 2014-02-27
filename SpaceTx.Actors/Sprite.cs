using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceTx.Actors
{
    public class Sprite
    {
        public Vector2 Position = new Vector2(100, 250);
        //The texture object used when drawing the sprite
        private Texture2D mSpriteTexture;

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position, Color.White);
        }
            
        public void LoadContent(GraphicsDevice gd, string theAssetName)
        {
            System.IO.Stream stream = TitleContainer.OpenStream("Content/" + theAssetName);
            mSpriteTexture = Texture2D.FromStream(gd, stream);
        }
    }
}
