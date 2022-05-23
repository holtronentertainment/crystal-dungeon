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
        public Transform2 Transform { get; set; } = new Transform2();

        public Kobold(int level, Vector2 position)
        {
            Name = "Kobold";
            Health = 10 * level;
            Speed = 30;
            Transform.Position = position;
        }

        public void Update(GameTime gameTime, Transform2 playerPosition)
        {
            if (Vector2.Distance(playerPosition.Position, Transform.Position) > 16)
            {
                Transform.Position += Vector2.Normalize(playerPosition.Position - Transform.Position) * Speed * gameTime.GetElapsedSeconds();
            }
        }
    }
}
