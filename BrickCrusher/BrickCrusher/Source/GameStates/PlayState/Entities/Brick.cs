using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Brick : Entity
    {
        //constructors
        public Brick(int pixelWidth, int pixelHeight, Texture2D sprite, Body body) : base(pixelWidth, pixelHeight, sprite, body)
        {

        }
    }
}
