using BrickCrusher.Source.GameStates.PlayState.Entities;
using BrickCrusher.Source.Util;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public static class LevelFactory
    {
        public static Level testLevel()
        {
            EntityLayer entityLayer = new EntityLayer();
            entityLayer.initBorder();
            entityLayer.initPaddle(4);
            entityLayer.addBall(16);
            Level level = new Level(entityLayer, ContentLoader.getImage("WhiteBackground"));
            return level;
        }
    }
}
