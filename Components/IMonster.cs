using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace crystal.dungeon.Components
{
    public interface IMonster
    {
        public Transform2 Transform { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }

        public void Update(GameTime gameTime, Transform2 playerPosition);
    }
}
