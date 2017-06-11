using BrickCrusher.Source.Core;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BrickCrusher.Source.GameStates
{
    public class GameStateManager : IVisual, IDynamic
    {
        private Stack<IGameState> _gameStates;

        public GameStateManager()
        {
            _gameStates = new Stack<IGameState>();
        }

        public void pushState(IGameState gameState)
        {
            _gameStates.Push(gameState);
        }

        public IGameState popState()
        {
            return _gameStates.Pop();
        }

        public IGameState peekState()
        {
            return _gameStates.Peek();
        }

        public void update(float dt)
        {
            peekState().update(dt);
        }

        public void draw(SpriteBatch spriteBatch, float dt)
        {
            peekState().draw(spriteBatch, dt);
        }
    }
}
