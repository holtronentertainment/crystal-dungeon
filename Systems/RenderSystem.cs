using crystal.dungeon.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.ViewportAdapters;

namespace crystal.dungeon.Systems
{
    public class RenderSystem : EntityDrawSystem
    {
        private GameWindow _gameWindow;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private OrthographicCamera _camera;
        private ComponentMapper<AnimatedSprite> _spriteMapper;
        private ComponentMapper<Transform2> _transformMapper;
        private ComponentMapper<TextComponent> _textMapper;
        private ComponentMapper<Button> _buttonMapper;
        private ComponentMapper<IMonster> _monsterMapper;
        private ComponentMapper<Player> _playerMapper;

        public RenderSystem(GameWindow gameWindow, GraphicsDevice graphicsDevice, OrthographicCamera camera)
            : base(Aspect.One(typeof(AnimatedSprite), typeof(TextComponent), typeof(Button)))
        {
            _gameWindow = gameWindow;
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _camera = camera;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _spriteMapper = mapperService.GetMapper<AnimatedSprite>();
            _transformMapper = mapperService.GetMapper<Transform2>();
            _textMapper = mapperService.GetMapper<TextComponent>();
            _buttonMapper = mapperService.GetMapper<Button>();
            _monsterMapper = mapperService.GetMapper<IMonster>();
            _playerMapper = mapperService.GetMapper<Player>();
        }

        public override void Draw(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.Transparent);
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            foreach(var entity in ActiveEntities)
            {
                if (_textMapper.Has(entity))
                {
                    var textComp = _textMapper.Get(entity);
                    _spriteBatch.DrawString(textComp.Font, textComp.Text, textComp.Transform.Position, textComp.TextColor, 0, Vector2.Zero, textComp.Transform.Scale, SpriteEffects.None, 0);
                }
                if (_spriteMapper.Has(entity))
                {
                    if(_playerMapper.Has(entity))
                    {
                        _spriteBatch.Draw(_spriteMapper.Get(entity), _playerMapper.Get(entity).Transform);
                    }
                    else if (_monsterMapper.Has(entity))
                    {
                        _spriteBatch.Draw(_spriteMapper.Get(entity), _monsterMapper.Get(entity).Transform);
                    }
                }
                if (_buttonMapper.Has(entity))
                {
                    var button = _buttonMapper.Get(entity);
                    if (button.Hovered)
                    {
                        _spriteBatch.Draw(button.HoveredTexture, button.CollisionBox, Color.White);
                        //_spriteBatch.FillRectangle(button.CollisionBox, button.HoverColor);
                    }
                    else
                    {
                        _spriteBatch.Draw(button.DefaultTexture, button.CollisionBox, Color.White);
                        //_spriteBatch.FillRectangle(button.CollisionBox, button.DefaultColor);
                    }

                    _spriteBatch.DrawString(button.Font, button.Text, new Vector2(button.CollisionBox.Left + 10, button.CollisionBox.Top + 10), button.TextColor);
                }
            }

            _spriteBatch.End();
        }
    }
}
