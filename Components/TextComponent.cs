using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace crystal.dungeon.Components
{
    public class TextComponent
    {
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Transform2 Transform { get; set; }
        public Color TextColor { get; set; }

        public TextComponent(SpriteFont font, string text, Transform2 transform, Color color)
        {
            Font = font;
            Text = text;
            Transform = transform;
            TextColor = color;
        }
    }
}
