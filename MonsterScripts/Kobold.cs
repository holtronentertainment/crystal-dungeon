using crystal.dungeon.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace crystal.dungeon.MonsterScripts
{
    public class Kobold : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public Rectangle CollisionBox { get; set; }
        public Transform2 Transform { get; set; } = new Transform2();

        public Kobold(int level, Vector2 position, Rectangle collisionBox)
        {
            Name = "Kobold";
            Health = 10 * level;
            Speed = 1;
            Transform.Position = position;
            CollisionBox = collisionBox;
        }

        public void Update(GameTime gameTime, Transform2 playerPosition)
        {
            if (!CollisionBox.Contains(playerPosition.Position))
            {
                Transform.Position += Vector2.Normalize(playerPosition.Position - Transform.Position) * Speed * gameTime.GetElapsedSeconds();
            }
        }
    }
}
