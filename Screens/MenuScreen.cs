﻿using crystal.dungeon.Components;
using crystal.dungeon.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using System.Collections.Generic;

namespace crystal.dungeon.Screens
{
    public class MenuScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private SpriteFont _spriteFont;
        private List<int> _screenEntities;

        public MenuScreen(Game game, SpriteFont spriteFont) : base(game)
        {
            _spriteFont = spriteFont;
            _screenEntities = new List<int>();
        }

        public override void LoadContent()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
            var titleTextEntity = Game.World.CreateEntity();
            titleTextEntity.Attach(new TextComponent(_spriteFont, "Crystal Dungeon", new Transform2(new Vector2(10, 10), 0, Vector2.One), Color.Black));
            _screenEntities.Add(titleTextEntity.Id);
            _screenEntities.Add(PlayerSystem.CreatePlayer(Game.World, Game.Content));
            _screenEntities.Add(ButtonSystem.CreateButtonEntity(Game.World, new Button("Single Player", Color.Black, Color.Blue, Color.LightBlue, new Rectangle(new Point(100, 200), new Point(200, 100)), _spriteFont, LoadSinglePlayerMenu)));
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        private void LoadSinglePlayerMenu()
        {
            foreach(var entity in _screenEntities)
            {
                Game.World.DestroyEntity(entity);
            }

            Game.ScreenManager.LoadScreen(new SinglePlayerMenuScreen(Game, _spriteFont));
        }
    }
}
