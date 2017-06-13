using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Ball : Entity
    {

        //constructors
        public Ball(float diameter, Texture2D sprite, Body body) : base((int)(diameter), (int)(diameter), sprite, body)
        {
            body.FixtureList[0].OnCollision += handleCollision;
        }

        //private methods
        private bool handleCollision (Fixture fixture1, Fixture fixture2, Contact contact)
        {
            return true;
        }
    }
}
