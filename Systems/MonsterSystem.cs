using crystal.dungeon.Components;
using crystal.dungeon.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;
using System.Collections.Generic;

namespace crystal.dungeon.Systems
{
    internal class MonsterSystem : EntityUpdateSystem
    {
        private ComponentMapper<IMonster> _monsterMapper;
        private ComponentMapper<Player> _playerMapper;
        private ComponentMapper<AnimatedSprite> _spriteMapper;

        public MonsterSystem() : base(Aspect.All(typeof(IMonster)))
        {
            
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _monsterMapper = mapperService.GetMapper<IMonster>();
            _playerMapper = mapperService.GetMapper<Player>();
            _spriteMapper = mapperService.GetMapper<AnimatedSprite>();
        }

        public override void Update(GameTime gameTime)
        {
            var player = _playerMapper.Components[0];
            foreach(var entity in ActiveEntities)
            {
                var monster = _monsterMapper.Get(entity);
                monster.Update(gameTime, player.Transform);
                if (_spriteMapper.Has(entity))
                {
                    _spriteMapper.Get(entity).Update(gameTime);
                }
            }
        }

        public static int SpawnMonster(IMonster monster, Texture2D texture, World world)
        {
            var entity = world.CreateEntity();
            entity.Attach(monster);

            var animations = new List<SpriteAnimationData>
            {
                new SpriteAnimationData("Down", 0, 3, 0.2f, true, true),
                new SpriteAnimationData("Left", 3, 3, 0.2f, true, true),
                new SpriteAnimationData("Right", 6, 3, 0.2f, true, true),
                new SpriteAnimationData("Up", 9, 3, 0.2f, true, true),
            };

            entity.Attach(AnimatedSpriteBuilder.Build(monster.Name + "Atlas", texture, 16, 20, 12, 0, 0, animations));
            return entity.Id;
        }
    }
}
