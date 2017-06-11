using BrickCrusher.Source.Core;

namespace BrickCrusher.Source.GameStates
{
    public interface IGameState : IDynamic, IVisual
    {
        void init();
        void dispose();
    }
}
