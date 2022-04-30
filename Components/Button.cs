using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace crystal.dungeon.Components
{
    public class Button
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Texture2D DefaultTexture { get; set; }
        public Texture2D HoveredTexture { get; set; }
        public Texture2D DisabledTexture { get; set; }
        public Rectangle CollisionBox { get; set; }
        public bool Hovered { get; set; }
        public bool Disabled { get; set; }
        public SpriteFont Font { get; set; }
        public Action Method { get; set; }

        public Button(string text, Color textColor, Texture2D defaultTexture, Texture2D hoveredTexture, Texture2D disabledTexture, Rectangle box, SpriteFont font, Action method)
        {
            Text = text;
            TextColor = textColor;
            DefaultTexture = defaultTexture;
            HoveredTexture = hoveredTexture;
            DisabledTexture = disabledTexture;
            CollisionBox = box;
            Font = font;
            Method = method;
        }
    }
}
