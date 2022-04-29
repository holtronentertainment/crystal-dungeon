using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System.Collections.Generic;
using System.Linq;

namespace crystal.dungeon.Helpers
{
    public static class AnimatedSpriteBuilder
    {
        public static AnimatedSprite Build(Texture2D spriteTexture, int spriteWidth, int spriteHeight, int maxFrames, int spacing, int margin, List<SpriteAnimationData> animationData)
        {
            var atlas = TextureAtlas.Create("Player Animations Atlas", spriteTexture, spriteWidth, spriteHeight, maxFrames, margin, spacing);

            var spriteSheet = new SpriteSheet
            {
                TextureAtlas = atlas,
                Cycles = new Dictionary<string, SpriteSheetAnimationCycle>()
            };

            foreach(var animation in animationData)
            {
                spriteSheet.Cycles.Add(animation.AnimationName, new SpriteSheetAnimationCycle
                {
                    IsLooping = animation.IsLooping,
                    IsPingPong = animation.IsPingPong,
                    FrameDuration = animation.FrameDuration,
                });

                for(int i = animation.FrameStart; i < animation.FrameStart + animation.Frames; i++)
                {
                    spriteSheet.Cycles[animation.AnimationName].Frames.Add(new SpriteSheetAnimationFrame(i));
                }
            }

            return new AnimatedSprite(spriteSheet, spriteSheet.Cycles.Keys.First());
        }
    }

    public class SpriteAnimationData
    {
        public string AnimationName { get; set; }
        public int FrameStart { get; set; }
        public int Frames { get; set; }
        public float FrameDuration { get; set; }
        public bool IsLooping { get; set; }
        public bool IsPingPong { get; set; }

        public SpriteAnimationData(string animationName, int frameStart, int frames, float frameDuration, bool isLooping, bool isPingPong)
        {
            AnimationName = animationName;
            FrameStart = frameStart;
            Frames = frames;
            FrameDuration = frameDuration;
            IsLooping = isLooping;
            IsPingPong = isPingPong;
        }
    }
}
