using crystal.dungeon.Components;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System.Collections.Generic;

namespace crystal.dungeon.Screens
{
    public class SinglePlayerMenuScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private List<int> _screenEntities;

        public SinglePlayerMenuScreen(Game game) : base(game)
        {
            _screenEntities = new List<int>();
        }

        public override void Initialize()
        {
            base.Initialize();
            var titleTextEntity = Game.World.CreateEntity();
            titleTextEntity.Attach(new TextComponent(Game.Font, "Crystal Dungeon", new Transform2(new Vector2(10, 10), 0, Vector2.One), Color.Black));
            _screenEntities.Add(titleTextEntity.Id);
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("New Game", Color.Black, Game.DefaultBtnTexture, Game.HoverBtnTexture, Game.DisabledBtnTexture, new Rectangle(new Point(100, 100), new Point(150, 45)), Game.Font, NewGameButton)));
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("Load Game", Color.Black, Game.DefaultBtnTexture, Game.HoverBtnTexture, Game.DisabledBtnTexture, new Rectangle(new Point(100, 150), new Point(150, 45)), Game.Font, LoadGameButton)));
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("Back", Color.Black, Game.DefaultBtnTexture, Game.HoverBtnTexture, Game.DisabledBtnTexture, new Rectangle(new Point(100, 200), new Point(150, 45)), Game.Font, BackButton)));
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {

        }

        private void NewGameButton()
        {
            CleanupEntities();
            Game.ScreenManager.LoadScreen(new TestScreen(Game));
        }

        private void LoadGameButton()
        {

        }

        private void BackButton()
        {
            CleanupEntities();
            Game.ScreenManager.LoadScreen(new MenuScreen(Game));
        }

        private void CleanupEntities()
        {
            foreach (var entity in _screenEntities)
            {
                Game.World.DestroyEntity(entity);
            }
        }
    }
}
