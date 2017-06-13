using Microsoft.Xna.Framework.Graphics;
using BrickCrusher.Source.Input;
using BrickCrusher.Source.Util;
using Microsoft.Xna.Framework.Input;
using BrickCrusher.Source.GameStates.PlayState;
using Microsoft.Xna.Framework;

namespace BrickCrusher.Source.GameStates
{
    public class MenuState : IGameState
    {
        public enum Screen { Main, Victory }

        //members
        private GameStateManager _gameStateManager;
        private InputHandler _inputHandler;
        private Texture2D _mainBackground;
        private Texture2D _victoryBackground;

        //properties
        public Screen CurrentScreen { get; set; }

        //constructors
        public MenuState(GameStateManager gameStateManager, InputHandler inputHandler)
        {
            _gameStateManager = gameStateManager;
            _inputHandler = inputHandler;
        }

        public void init()
        {
            _mainBackground = ContentLoader.getImage("MainBackground");
            _victoryBackground = ContentLoader.getImage("VictoryBackground");
            CurrentScreen = Screen.Main;
        }

        public void dispose()
        {

        }
        
        public void update(float dt)
        {
            if (_inputHandler.isKeyPressedThisFrame(Keys.Enter))
            {
                if (CurrentScreen == Screen.Main) { launchGame(); }
                if (CurrentScreen == Screen.Victory) { CurrentScreen = Screen.Main; }
            }
        }

        public void draw(SpriteBatch spriteBatch, float dt)
        {
            Texture2D texture = null;
            if (CurrentScreen == Screen.Main) { texture = _mainBackground; }
            else if (CurrentScreen == Screen.Victory) { texture = _victoryBackground; }

            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }

        private void launchGame()
        {
            _gameStateManager.pushState(new PlayingState(_gameStateManager, _inputHandler));
            _gameStateManager.peekState().init();
        }
    }
}
