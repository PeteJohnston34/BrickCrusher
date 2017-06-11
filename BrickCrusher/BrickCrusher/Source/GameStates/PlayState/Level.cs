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

        //constructors
        public Level(EntityLayer entityLayer, Texture2D background)
        {
            _entityLayer = entityLayer;
            _background = background;
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
