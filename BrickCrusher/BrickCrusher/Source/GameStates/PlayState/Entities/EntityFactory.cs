using BrickCrusher.Source.Util;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static BrickCrusher.Source.Util.GlobalConstants;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public static class EntityFactory
    {
        public static Ball createBall(World world, Vector2 pixelLocation, int pixelDiameter)
        {
            Body body = new Body(world, pixelLocation / PPM);
            body.BodyType = BodyType.Dynamic;
            FixtureFactory.AttachCircle((pixelDiameter / PPM) / 2.0f, DEFAULT_DENSITY, body);
            body.FixtureList[0].Restitution = 1f;
            body.FixtureList[0].Friction = 0f;
            Ball ball = new Ball(pixelDiameter, ContentLoader.getImage("Ball" + pixelDiameter), body);
            body.ApplyLinearImpulse(new Vector2(5f, -5f));
            return ball;
        }

        public static Brick createRectangularBrick(World world, Vector2 pixelLocation, int pixelWidth, int pixelHeight, string color, EntityLayer entityLayer)
        {
            Body body = new Body(world, new Vector2(pixelLocation.X / PPM, pixelLocation.Y / PPM));
            body.BodyType = BodyType.Static;
            FixtureFactory.AttachRectangle(pixelWidth / PPM, pixelHeight / PPM, DEFAULT_DENSITY, Vector2.Zero, body);
            body.FixtureList[0].Restitution = 0f;
            body.FixtureList[0].Friction = 0f;
            Brick brick = new Brick(pixelWidth, pixelHeight, ContentLoader.getImage(color + "Block" + pixelWidth), body);
            brick.registerEventHandler(entityLayer.handleBrickDestory);
            return brick;
        }

        public static Paddle createPaddle(World world, Vector2 pixelLocation, int segments)
        {
            Texture2D[] paddleSprites = new Texture2D[3];
            paddleSprites[(int)Paddle.PaddleSprite.LEFT] = ContentLoader.getImage("PaddleLeft");
            paddleSprites[(int)Paddle.PaddleSprite.MIDDLE] = ContentLoader.getImage("PaddleMiddle");
            paddleSprites[(int)Paddle.PaddleSprite.RIGHT] = ContentLoader.getImage("PaddleRight");

            Body body = new Body(world, new Vector2(pixelLocation.X / PPM, pixelLocation.Y / PPM));
            Body shadowBody = new Body(world, new Vector2(pixelLocation.X / PPM, pixelLocation.Y / PPM));
            body.BodyType = BodyType.Dynamic;
            shadowBody.BodyType = BodyType.Kinematic;
            FixtureFactory.AttachRectangle(segments * Paddle.SEGMENT_PIXEL_WIDTH / PPM, Paddle.PADDLE_HEIGHT / PPM, DEFAULT_DENSITY, Vector2.Zero, body);
            FixtureFactory.AttachRectangle(segments * Paddle.SEGMENT_PIXEL_WIDTH / PPM, Paddle.PADDLE_HEIGHT / PPM, DEFAULT_DENSITY, Vector2.Zero, shadowBody);
            body.FixtureList[0].Restitution = 0f;
            body.FixtureList[0].Friction = 0f;
            shadowBody.FixtureList[0].Restitution = 0f;
            shadowBody.FixtureList[0].Friction = 0f;
            Paddle paddle = new Paddle(segments, paddleSprites, body, shadowBody);
            return paddle;
        }
    }
}
