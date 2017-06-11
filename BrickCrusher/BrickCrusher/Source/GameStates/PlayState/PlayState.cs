using BrickCrusher.Source.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public class PlayState : IGameState
    {
        //members
        private GameStateManager _gameStateManager;
        private Level _currentLevel;
        private InputHandler _inputHandler;

        //constructors
        public PlayState(GameStateManager gameStateManager, InputHandler inputHandler)
        {
            _gameStateManager = gameStateManager;
            _inputHandler = inputHandler;
        }

        
        // public methods                
        public void init()
        {
            //Test
            _currentLevel = LevelFactory.testLevel();
        }

        public void dispose()
        {

        }

        public void update(float dt)
        {
            queryInput();
            _currentLevel.update(dt);
        }

        public void draw(SpriteBatch spriteBatch, float dt)
        {
            _currentLevel.draw(spriteBatch, dt);
        }

        //private methods
        private void queryInput()
        {
            if (_inputHandler.isKeyPressed(Keys.A) || _inputHandler.isKeyPressed(Keys.Left))
            {
                _currentLevel.movePaddleLeft();
            }

            if (_inputHandler.isKeyPressed(Keys.D) || _inputHandler.isKeyPressed(Keys.Right))
            {
                _currentLevel.movePaddleRight();
            }

            //if (_inputHandler.isKeyReleasedThisFrame(Keys.A) && !_inputHandler.isKeyPressed(Keys.D) ||
            //    _inputHandler.isKeyReleasedThisFrame(Keys.D) && !_inputHandler.isKeyPressed(Keys.A) ||
            //    _inputHandler.isKeyReleasedThisFrame(Keys.Left) && !_inputHandler.isKeyPressed(Keys.Right) ||
            //    _inputHandler.isKeyReleasedThisFrame(Keys.Right) && !_inputHandler.isKeyPressed(Keys.Left))
            //{
            //    _currentLevel.stopPaddle();
            //}
        }
    }
}
