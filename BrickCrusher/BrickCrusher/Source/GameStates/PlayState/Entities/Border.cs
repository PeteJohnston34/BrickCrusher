using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static BrickCrusher.Source.Util.GlobalConstants;

namespace BrickCrusher.Source.GameStates.PlayState.Entities
{
    public class Border : Entity
    {
        //constructors
        public Border(Body body) : base(SCREEN_WIDTH, SCREEN_HEIGHT, null, body)
        {
            defaultBorder(body);
            body.FixtureList.ForEach(e => e.OnCollision += handleCollision);                 
        }

        //private methods
        private bool handleCollision(Fixture fixture1, Fixture fixture2, Contact contact)
        {
            Console.WriteLine("Border Collision");
            return true;
        }

        private void defaultBorder(Body body)
        {
            float borderWidth = 0.5f;
            float physicsWidth = SCREEN_WIDTH / PPM;
            float physicsHeight = SCREEN_HEIGHT / PPM;

            List<Vertices> vertices = new List<Vertices>();
            vertices.Add(PolygonTools.CreateRectangle(borderWidth / 2, physicsHeight / 2, new Vector2(borderWidth / 2, physicsHeight / 2), 0));
            vertices.Add(PolygonTools.CreateRectangle(borderWidth / 2, physicsHeight / 2, new Vector2(PhysicsWidth - (borderWidth / 2), physicsHeight / 2), 0));
            vertices.Add(PolygonTools.CreateRectangle(physicsWidth / 2, borderWidth / 2, new Vector2(physicsWidth / 2, borderWidth / 2), 0));
            FixtureFactory.AttachCompoundPolygon(vertices, DEFAULT_DENSITY, body);
        }
    }
}
