using Microsoft.Xna.Framework.Graphics;

namespace BrickCrusher.Source.Core
{
    public interface IVisual
    {
        void draw(SpriteBatch spriteBatch, float dt);
    }
}
