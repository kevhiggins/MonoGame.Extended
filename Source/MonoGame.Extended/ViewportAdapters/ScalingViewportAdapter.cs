using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// ReSharper disable once CheckNamespace
namespace MonoGame.Extended.ViewportAdapters
{
    public class ScalingViewportAdapter : ViewportAdapter
    {
        public ScalingViewportAdapter(GraphicsDevice graphicsDevice, float virtualWidth, float virtualHeight) 
            : base(graphicsDevice)
        {
            VirtualWidth = virtualWidth;
            VirtualHeight = virtualHeight;
        }

        public override float VirtualWidth { get; }
        public override float VirtualHeight { get; }
        public override int ViewportWidth => GraphicsDevice.Viewport.Width;
        public override int ViewportHeight => GraphicsDevice.Viewport.Height;

        public override Matrix GetScaleMatrix()
        {
            var scaleX = (float)ViewportWidth / VirtualWidth;
            var scaleY = (float)ViewportHeight / VirtualHeight;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
    }
}