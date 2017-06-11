using BrickCrusher.Source.Core;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using static BrickCrusher.Source.Util.GlobalConstants;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Entity : IDynamic, IVisual
    {
        //members
        private Body _body;
        private Texture2D _sprite;

        //properties
        public int PixelWidth { get; protected set; }
        public int PixelHeight { get; protected set; }
        public int HalfPixelWidth { get { return PixelWidth / 2; } }
        public int HalfPixelHeight { get { return PixelHeight / 2; } }
        public float PhysicsWidth { get { return PixelWidth / PPM; } }
        public float PhysicsHeight { get { return PixelHeight / PPM; } }
        public Vector2 PhysicsPosition { get { return GetBody.Position; } }
        public Vector2 PixelPosition { get { return new Vector2(PhysicsPosition.X * PPM, PhysicsPosition.Y * PPM); } }
        public Vector2 TopLeft { get { return new Vector2(PixelPosition.X - HalfPixelWidth, PixelPosition.Y - HalfPixelHeight); } }
        public Body GetBody
        {
            get { return _body; }
            private set { _body = value; }
        }
        public Texture2D GetSprite
        {
            get { return _sprite; }
            private set { _sprite = value; }
        }
        
        //constructors
        public Entity(int pixelWidth, int pixelHeight, Texture2D sprite, Body body)
        {
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
            GetBody = body;            
            GetSprite = sprite;
        }

        //virtual methods
        public virtual void dispose()
        {
            _body.Dispose();            
        }

        public virtual void update(float dt)
        {

        }

        public virtual void draw(SpriteBatch spriteBatch, float dt)
        {
            spriteBatch.Draw(_sprite, TopLeft, Color.White);
        }
    }
}
