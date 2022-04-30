using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace crystal.dungeon.Components
{
    public class Button
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color DefaultColor { get; set; }
        public Color HoverColor { get; set; }
        public Rectangle CollisionBox { get; set; }
        public bool Hovered { get; set; }
        public SpriteFont Font { get; set; }
        public Action Method { get; set; }

        public Button(string text, Color textColor, Color defaultColor, Color hoverColor, Rectangle box, SpriteFont font, Action method)
        {
            Text = text;
            TextColor = textColor;
            DefaultColor = defaultColor;
            HoverColor = hoverColor;
            CollisionBox = box;
            Font = font;
            Method = method;
        }
    }
}
