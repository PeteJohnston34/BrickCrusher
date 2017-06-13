using BrickCrusher.Source.Core;
using BrickCrusher.Source.GameStates.PlayState.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public class Level : IDynamic, IVisual
    {
        //members
        private EntityLayer _entityLayer;
        private Texture2D _background;

        //properties
        public PlayingState Parent { get; private set; }

        //constructors
        public Level(EntityLayer entityLayer, Texture2D background, PlayingState parent)
        {
            _entityLayer = entityLayer;
            _background = background;
            Parent = parent;
        }

        //public methods
        public void movePaddleLeft()
        {
            _entityLayer.movePaddleLeft();
        }

        public void movePaddleRight()
        {
            _entityLayer.movePaddleRight();
        }

        public void addBall()
        {
            _entityLayer.addBall(16);
        }

        public void dispose()
        {
            _entityLayer.dispose();
        }

        public void update(float dt)
        {
            _entityLayer.update(dt);
        }

        public void draw(SpriteBatch spriteBatch, float dt)
        {
            spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _entityLayer.draw(spriteBatch, dt);
        }
    }
}
