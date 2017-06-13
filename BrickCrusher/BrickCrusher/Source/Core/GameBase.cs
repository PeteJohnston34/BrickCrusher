using BrickCrusher.Source.GameStates;
using BrickCrusher.Source.GameStates.PlayState;
using BrickCrusher.Source.Input;
using BrickCrusher.Source.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BrickCrusher.Source.Core
{
    public class GameBase : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private InputHandler _inputHandler;
        private GameStateManager _gameStateManager;

        public GameBase()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalConstants.SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = GlobalConstants.SCREEN_HEIGHT;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ContentLoader.initLoader(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _inputHandler = new InputHandler();
            _gameStateManager = new GameStateManager();
            _gameStateManager.pushState(new MenuState(_gameStateManager, _inputHandler));
            _gameStateManager.peekState().init();

            base.Initialize();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            _inputHandler.update(dt);
            _gameStateManager.update(dt);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _gameStateManager.draw(_spriteBatch, dt);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
