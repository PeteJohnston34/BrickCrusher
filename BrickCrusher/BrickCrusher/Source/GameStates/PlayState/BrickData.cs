using Microsoft.Xna.Framework;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public class BrickData
    {
        //private members
        private int _index;
        private Vector2[] _brickPositions;

        //properties
        public int NumberOfBricks { get; private set; }
        public Vector2[] BrickPositions { get { return _brickPositions; } }

        //constructors
        public BrickData(int numberOfBricks)
        {
            NumberOfBricks = numberOfBricks;
            _brickPositions = new Vector2[numberOfBricks];
            _index = 0;
        }

        //public methods
        public void addBrick(Vector2 position)
        {
            if(_index == NumberOfBricks) { return; }
            _brickPositions[_index++] = position;
        }
    }
}
