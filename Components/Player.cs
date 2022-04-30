using System;

namespace crystal.dungeon.Components
{
    public class Player
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int Armor { get; set; }

        public Player()
        {

        }

        public void TakeDamage(int damage)
        {
            Health -= Math.Clamp(damage - Armor, 0, damage);
        }
    }
}
