using System;

namespace BrickCrusher.Source.Core
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameBase())
                game.Run();
        }
    }
#endif
}
