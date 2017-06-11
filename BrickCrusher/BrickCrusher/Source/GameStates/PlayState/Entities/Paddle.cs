using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static BrickCrusher.Source.Util.GlobalConstants;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Paddle : Entity
    {
        public enum PaddleSprite { LEFT, MIDDLE, RIGHT }

        //constants
        public const int PADDLE_HEIGHT = 8;
        public const int SEGMENT_PIXEL_WIDTH = 16;
        public static readonly Vector2 DEFAULT_PADDLE_LOCATION = new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT - (PADDLE_HEIGHT * 2));

        //members
        private Texture2D[] _sprites;
        private Body _shadowBody;

        //Properties
        public int Segments { get; set; }

        //constructors
        public Paddle(int segments, Texture2D[] sprites, Body body, Body shadowBody) : base(segments * SEGMENT_PIXEL_WIDTH, PADDLE_HEIGHT, null, body)
        {
            _sprites = sprites;
            _shadowBody = shadowBody;
            Segments = segments;
            body.FixtureList[0].OnCollision += handleCollision;
            shadowBody.FixtureList[0].OnCollision += handleShadowCollision;
        }

        //public methods
        public void resize(int segments)
        {
            if (segments == Segments || segments < 3 || segments > 30) { return; }
            if (GetBody.Position.X - (HalfPixelWidth / PPM) < 0) { GetBody.Position = new Vector2(HalfPixelWidth / PPM, GetBody.Position.Y); }
            if (GetBody.Position.X + (HalfPixelWidth / PPM) > SCREEN_WIDTH) { GetBody.Position = new Vector2((SCREEN_WIDTH - HalfPixelWidth) / PPM, GetBody.Position.Y); }

            Segments = segments;
            PixelWidth = Segments * SEGMENT_PIXEL_WIDTH;            
            GetBody.DestroyFixture(GetBody.FixtureList[0]);
            GetBody.CreateFixture(new PolygonShape(PolygonTools.CreateRectangle(PixelWidth / PPM / 2, Paddle.PADDLE_HEIGHT / PPM / 2, PhysicsPosition, 0), DEFAULT_DENSITY));
            GetBody.FixtureList[0].OnCollision += handleCollision;
        }

        public override void dispose()
        {
            _shadowBody.Dispose();
            base.dispose();
        }

        public override void update(float dt)
        {
            _shadowBody.Position = GetBody.Position;
            _shadowBody.LinearVelocity = GetBody.LinearVelocity;
            _shadowBody.AngularVelocity = GetBody.AngularVelocity;
        }

        public override void draw(SpriteBatch spriteBatch, float dt)
        {
            int xPos = (int)TopLeft.X + SEGMENT_PIXEL_WIDTH;
            spriteBatch.Draw(_sprites[(int)PaddleSprite.LEFT], TopLeft, Color.White);

            for (int i = 0; i < Segments - 2; i++)
            {
                spriteBatch.Draw(_sprites[(int)PaddleSprite.MIDDLE], new Vector2(xPos, TopLeft.Y), Color.White);
                xPos += SEGMENT_PIXEL_WIDTH;
            }

            spriteBatch.Draw(_sprites[(int)PaddleSprite.RIGHT], new Vector2(xPos, TopLeft.Y), Color.White);
        }

        //private methods
        private bool handleCollision(Fixture fixture1, Fixture fixture2, Contact contact)
        {
            if (fixture1.Body.BodyType == BodyType.Static || fixture2.Body.BodyType == BodyType.Static) { return true; }
            return false;
        }

        private bool handleShadowCollision(Fixture fixture1, Fixture fixture2, Contact contact)
        {
            return true;
        }
    }
}
