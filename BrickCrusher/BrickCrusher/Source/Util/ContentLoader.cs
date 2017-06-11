using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BrickCrusher.Source.Util
{
    public class ContentLoader
    {
        private static ContentManager _contentManager;

        public static void initLoader(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public static Texture2D getImage(string name)
        {
            if (_contentManager == null) { return null; }

            return _contentManager.Load<Texture2D>(name);
        }
    }
}
