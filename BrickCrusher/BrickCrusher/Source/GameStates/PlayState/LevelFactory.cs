using BrickCrusher.Source.GameStates.PlayState.Entities;
using BrickCrusher.Source.Util;
using Microsoft.Xna.Framework;

namespace BrickCrusher.Source.GameStates.PlayState
{
    public static class LevelFactory
    {
        public static Level testLevel(PlayingState playingState)
        {
            EntityLayer entityLayer = new EntityLayer();
            entityLayer.initBorder();
            entityLayer.initPaddle(4);

            BrickData brickData = new BrickData(24);

            brickData.addBrick(new Vector2(100, 100));
            brickData.addBrick(new Vector2(164, 100));
            brickData.addBrick(new Vector2(228, 100));
            brickData.addBrick(new Vector2(292, 100));
            brickData.addBrick(new Vector2(356, 100));
            brickData.addBrick(new Vector2(420, 100));
            brickData.addBrick(new Vector2(484, 100));
            brickData.addBrick(new Vector2(548, 100));

            brickData.addBrick(new Vector2(100, 132));
            brickData.addBrick(new Vector2(164, 132));
            brickData.addBrick(new Vector2(228, 132));
            brickData.addBrick(new Vector2(292, 132));
            brickData.addBrick(new Vector2(356, 132));
            brickData.addBrick(new Vector2(420, 132));
            brickData.addBrick(new Vector2(484, 132));
            brickData.addBrick(new Vector2(548, 132));

            brickData.addBrick(new Vector2(100, 164));
            brickData.addBrick(new Vector2(164, 164));
            brickData.addBrick(new Vector2(228, 164));
            brickData.addBrick(new Vector2(292, 164));
            brickData.addBrick(new Vector2(356, 164));
            brickData.addBrick(new Vector2(420, 164));
            brickData.addBrick(new Vector2(484, 164));
            brickData.addBrick(new Vector2(548, 164));

            entityLayer.initBricks(brickData);
            entityLayer.addBall(16);
            Level level = new Level(entityLayer, ContentLoader.getImage("WhiteBackground"), playingState);
            entityLayer.registerParent(level);
            return level;
        }
    }
}
