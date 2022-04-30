using crystal.dungeon.Components;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crystal.dungeon.Screens
{
    public class TestScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private List<int> _screenEntities = new List<int>();

        public TestScreen(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            var titleTextEntity = Game.World.CreateEntity();
            titleTextEntity.Attach(new TextComponent(Game.Font, "Crystal Dungeon", new Transform2(new Vector2(10, 10), 0, Vector2.One), Color.Red));
            _screenEntities.Add(titleTextEntity.Id);
            _screenEntities.Add(PlayerSystem.CreatePlayer(Game.World, Game.Content));
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            
        }
    }
}
