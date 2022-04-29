using crystal.dungeon.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System.Collections.Generic;

namespace crystal.dungeon.Characters
{
    public class Player
    {
        private readonly AnimatedSprite sprite;
        private readonly Texture2D _playerTexture;

        public Player(Texture2D playerTexture)
        {
            _playerTexture = playerTexture;

            var animations = new List<SpriteAnimationData>
            {
                new SpriteAnimationData("Down", 0, 3, 0.2f, true, true),
                new SpriteAnimationData("Left", 3, 3, 0.2f, true, true),
                new SpriteAnimationData("Right", 6, 3, 0.2f, true, true),
                new SpriteAnimationData("Up", 9, 3, 0.2f, true, true),
            };

            sprite = AnimatedSpriteBuilder.Build(_playerTexture, 16, 20, 12, 0, 0, animations);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                sprite.Play("Left");
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                sprite.Play("Right");
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                sprite.Play("Up");
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                sprite.Play("Down");
            }

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(100, 100));
        }
    }
}
