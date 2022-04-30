using crystal.dungeon.Components;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crystal.dungeon.Screens
{
    public class SinglePlayerMenuScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private List<int> _screenEntities;
        private SpriteFont _spriteFont;

        public SinglePlayerMenuScreen(Game game, SpriteFont spriteFont) : base(game)
        {
            _screenEntities = new List<int>();
            _spriteFont = spriteFont;
        }

        public override void Initialize()
        {
            base.Initialize();
            var titleTextEntity = Game.World.CreateEntity();
            titleTextEntity.Attach(new TextComponent(_spriteFont, "Crystal Dungeon", new Transform2(new Vector2(10, 10), 0, Vector2.One), Color.Black));
            _screenEntities.Add(titleTextEntity.Id);
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("New Game", Color.Black, Color.Blue, Color.LightBlue, new Rectangle(new Point(100, 100), new Point(150, 45)), _spriteFont, NewGameButton)));
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("Load Game", Color.Black, Color.Blue, Color.LightBlue, new Rectangle(new Point(100, 150), new Point(150, 45)), _spriteFont, LoadGameButton)));
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("Back", Color.Black, Color.Blue, Color.LightBlue, new Rectangle(new Point(100, 200), new Point(150, 45)), _spriteFont, BackButton)));
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {

        }

        private void NewGameButton()
        {

        }

        private void LoadGameButton()
        {

        }

        private void BackButton()
        {

        }
    }
}
