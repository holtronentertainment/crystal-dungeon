using crystal.dungeon.Components;
using crystal.dungeon.MonsterScripts;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System.Collections.Generic;

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
            
            var kobold = new Kobold(1, new Vector2(200, 200));
            var kobold2 = new Kobold(1, new Vector2(250, 250));
            _screenEntities.Add(MonsterSystem.SpawnMonster(kobold, Game.Content.Load<Texture2D>("SpriteSheets/Kobold_1"), Game.World));
            _screenEntities.Add(MonsterSystem.SpawnMonster(kobold2, Game.Content.Load<Texture2D>("SpriteSheets/Kobold_1"), Game.World));
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            
        }
    }
}
