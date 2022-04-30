using crystal.dungeon.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace crystal.dungeon.Systems
{
    public class ButtonSystem : EntityUpdateSystem
    {
        private ComponentMapper<Button> _buttonMapper;
        private OrthographicCamera _camera;

        public ButtonSystem(OrthographicCamera camera) : base(Aspect.All(typeof(Button)))
        {
            _camera = camera;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _buttonMapper = mapperService.GetMapper<Button>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var entity in ActiveEntities)
            {
                var button = _buttonMapper.Get(entity);
                var mouseState = Mouse.GetState();

                if(button.CollisionBox.Contains(_camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y))))
                {
                    button.Hovered = true;
                    if (mouseState.LeftButton == ButtonState.Pressed && button.Method != null)
                    {
                        button.Method();
                    }
                }
                else
                {
                    button.Hovered = false;
                }
            }
        }

        public static int CreateButtonEntity(World world, Button button)
        {
            var entity = world.CreateEntity();
            entity.Attach(button);
            return entity.Id;
        }
    }
}
