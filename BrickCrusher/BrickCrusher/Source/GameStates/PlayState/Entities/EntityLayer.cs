using BrickCrusher.Source.Core;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static BrickCrusher.Source.Util.GlobalConstants;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class EntityLayer : IDynamic, IVisual
    {
        //members
        private World _world;
        private Border _border;
        private Ball[] _balls;
        private Paddle _paddle;
        private List<Brick> _bricks;
        private int _ballCount;

        //properties
        public Level Parent { get; private set; }
        public Ball[] Balls { get { return _balls; } }
        public Paddle GetPaddle { get { return _paddle; } }
        public List<Brick> Bricks { get { return _bricks; } }

        //constructors
        public EntityLayer()
        {
            _world = new World(new Vector2(0f, 0f));
            _balls = new Ball[5];
            _bricks = new List<Brick>();
            _ballCount = 0;
        }

        //public methods
        public void initBorder()
        {
            Body body = new Body(_world);
            body.BodyType = BodyType.Static;
            _border = new Border(body);
        }

        public void initPaddle(int segments)
        {
            _paddle = EntityFactory.createPaddle(_world, Paddle.DEFAULT_PADDLE_LOCATION, segments);
        }

        public void initBricks(BrickData brickData)
        {
            for (int i = 0; i < brickData.NumberOfBricks; i++)
            {
                //TODO: Implement different type of bricks
                Vector2 currentPosition = brickData.BrickPositions[i];
                _bricks.Add(EntityFactory.createRectangularBrick(_world, currentPosition, 64, 32, "Blue", this));
            }
        }

        public void registerParent(Level parent)
        {
            Parent = parent;
        }

        public void addBall(int pixelDiameter)
        {
            if(_ballCount == _balls.Length) { return; }
            Vector2 position;

            if (_paddle == null) { position = new Vector2(100, 100); }
            else { position = new Vector2(_paddle.PixelPosition.X, _paddle.PixelPosition.Y - (pixelDiameter / 2) - (Paddle.PADDLE_HEIGHT / 2)); }

            _balls[_ballCount] = EntityFactory.createBall(_world, position, pixelDiameter);
            _ballCount++;
        }

        public void movePaddleLeft()
        {
            if (_paddle.GetBody.LinearVelocity.X > 0) { _paddle.GetBody.LinearVelocity = new Vector2(_paddle.GetBody.LinearVelocity.X * .95f, 0); }
            _paddle.GetBody.ApplyForce(new Vector2(-30, 0), _paddle.GetBody.WorldCenter);
        }

        public void movePaddleRight()
        {
            if (_paddle.GetBody.LinearVelocity.X < 0) { _paddle.GetBody.LinearVelocity = new Vector2(_paddle.GetBody.LinearVelocity.X * .95f, 0); }
            _paddle.GetBody.ApplyForce(new Vector2(30, 0), _paddle.GetBody.WorldCenter);
        }

        public void handleBrickDestory(Brick brick)
        {
            _bricks.Remove(brick);
            brick.dispose();
            if (_bricks.Count == 0) { Parent.Parent.endStateVictory(); }
            //increment score
            //animation
        }

        public void dispose()
        {
            for (int i = 0; i < _ballCount; i++)
            {
                _balls[i].dispose();
            }
            _bricks.ForEach(e => e.dispose());
            _paddle.dispose();
            _border.dispose();
        }

        public void update(float dt)
        {
            if (_ballCount == 0) { addBall(16); }

            _world.Step(dt);
            _paddle.update(dt);
            for(int i = 0; i < _ballCount; i++)
            {
                _balls[i].update(dt);
                if (_balls[i].PixelPosition.Y > SCREEN_HEIGHT)
                {
                    _balls[i].dispose();
                    if(i < _ballCount - 1)
                    {
                        _balls[i] = _balls[_ballCount - 1];
                        _balls[_ballCount - 1] = null;
                    }
                    _ballCount--;
                }
            }

            _bricks.ForEach(e => e.update(dt));
        }

        public void draw(SpriteBatch spriteBatch, float dt)
        {
            _bricks.ForEach(e => e.draw(spriteBatch, dt));
            for (int i = 0; i < _ballCount; i++)
            {
                _balls[i].draw(spriteBatch, dt);
            }
            _paddle.draw(spriteBatch, dt);
        }
    }
}
