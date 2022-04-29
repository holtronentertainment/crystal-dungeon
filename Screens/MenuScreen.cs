using crystal.dungeon.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;

namespace crystal.dungeon.Screens
{
    public class MenuScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private OrthographicCamera _camera;
        private SpriteFont _spriteFont;

        // For Testing
        private Texture2D _playerSpriteSheet;
        private Player _player;

        public MenuScreen(Game game) : base(game)
        { }

        public override void Initialize()
        {
            base.Initialize();

            var viewportAdapter = new BoxingViewportAdapter(Game.Window, Game.GraphicsDevice, 1280, 720);
            _camera = new OrthographicCamera(viewportAdapter);
        }

        public override void LoadContent()
        {
            _spriteFont = Game.Content.Load<SpriteFont>("Fonts/KenneyFuture");
            _playerSpriteSheet = Game.Content.Load<Texture2D>("SpriteSheets/Cat_F2");
            _player = new Player(_playerSpriteSheet);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.DarkRed);
            Game.SpriteBatch.Begin();
            Game.SpriteBatch.DrawString(_spriteFont, "Crystal Dungeon", new Vector2(10, 10), Color.Black);
            _player.Draw(Game.SpriteBatch);
            Game.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }
    }
}
