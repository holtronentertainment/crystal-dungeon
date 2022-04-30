using crystal.dungeon.Components;
using crystal.dungeon.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;
using System.Collections.Generic;

namespace crystal.dungeon.Systems
{
    public class PlayerSystem : EntityUpdateSystem
    {
        private ContentManager _contentManager;
        private ComponentMapper<AnimatedSprite> _spriteMapper;
        private ComponentMapper<Player> _playerMapper;

        public PlayerSystem(ContentManager contentManager) : base(Aspect.All(typeof(Player)))
        {
            _contentManager = contentManager;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _spriteMapper = mapperService.GetMapper<AnimatedSprite>();
            _playerMapper = mapperService.GetMapper<Player>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var entity in ActiveEntities)
            {
                var sprite = _spriteMapper.Get(entity);

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    sprite.Play("Left");
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
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
        }

        public static int CreatePlayer(World world, ContentManager contentManager)
        {
            var texture = contentManager.Load<Texture2D>("SpriteSheets/Cat_F2");
            var animations = new List<SpriteAnimationData>
            {
                new SpriteAnimationData("Down", 0, 3, 0.2f, true, true),
                new SpriteAnimationData("Left", 3, 3, 0.2f, true, true),
                new SpriteAnimationData("Right", 6, 3, 0.2f, true, true),
                new SpriteAnimationData("Up", 9, 3, 0.2f, true, true),
            };
            var entity = world.CreateEntity();
            entity.Attach(new Player());
            entity.Attach(AnimatedSpriteBuilder.Build(texture, 16, 20, 12, 0, 0, animations));
            entity.Attach(new Transform2(100, 100));
            return entity.Id;
        }
    }
}
