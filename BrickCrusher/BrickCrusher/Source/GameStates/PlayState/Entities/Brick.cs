using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Brick : Entity
    {
        //delegates and events
        public delegate void brickDestroy(Brick brick);
        private event brickDestroy onBrickDestroy;

        //properties
        public int HitPoints { get; private set; }
        
        //constructors
        public Brick(int pixelWidth, int pixelHeight, Texture2D sprite, Body body) : base(pixelWidth, pixelHeight, sprite, body)
        {
            GetBody.FixtureList[0].OnCollision += handleCollision;
        }

        //public methods
        public void registerEventHandler(brickDestroy handler)
        {
            onBrickDestroy += handler;
        }

        //private methods
        private bool handleCollision(Fixture fixture1, Fixture fixture2, Contact contact)
        {
            HitPoints--;
            if (HitPoints <= 0) { onBrickDestroy(this); }

            return true;
        }

    }
}
