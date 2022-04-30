using crystal.dungeon.Screens;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.ViewportAdapters;

namespace crystal.dungeon
{
    public class Game1 : Game
    {
        public readonly ScreenManager ScreenManager;
        public SpriteBatch SpriteBatch;
        public World World;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteFont _spriteFont;
        private OrthographicCamera _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenManager = new ScreenManager();

            Components.Add(ScreenManager);
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1280, 720);
            _camera = new OrthographicCamera(viewportAdapter);

            World = new WorldBuilder()
                .AddSystem(new RenderSystem(Window, GraphicsDevice, _camera))
                .AddSystem(new PlayerSystem(Content))
                .AddSystem(new ButtonSystem(_camera))
                .Build();
            Components.Add(World);

            LoadMenuScreen();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteFont = Content.Load<SpriteFont>("Fonts/KenneyFuture");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            World.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            World.Draw(gameTime);

            base.Draw(gameTime);
        }

        private void LoadMenuScreen()
        {
            ScreenManager.LoadScreen(new MenuScreen(this, _spriteFont), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}
