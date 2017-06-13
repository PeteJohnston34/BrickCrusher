using BrickCrusher.Source.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static BrickCrusher.Source.GameStates.MenuState;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public class PlayingState : IGameState
    {
        //members
        private GameStateManager _gameStateManager;
        private Level _currentLevel;
        private InputHandler _inputHandler;

        //constructors
        public PlayingState(GameStateManager gameStateManager, InputHandler inputHandler)
        {
            _gameStateManager = gameStateManager;
            _inputHandler = inputHandler;
        }

        
        // public methods                
        public void init()
        {
            //Test
            _currentLevel = LevelFactory.testLevel(this);
        }

        public void endStateVictory()
        {
            dispose();
            _gameStateManager.popState();
            if(_gameStateManager.peekState() is MenuState)
            {
                MenuState menuState = (MenuState)_gameStateManager.peekState();
                menuState.CurrentScreen = Screen.Victory;
            }
        }

        public void dispose()
        {
            _currentLevel.dispose();
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

            if (_inputHandler.isKeyPressedThisFrame(Keys.Space))
            {
                _currentLevel.addBall();
            }
        }
    }
}
