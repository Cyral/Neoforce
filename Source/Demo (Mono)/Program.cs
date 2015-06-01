using System;
using Microsoft.Xna.Framework;

namespace MonoForce.Demo
{
    /// <summary>
    /// The main class for the MonoGame MonoForce Demo.
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //Create an instance of the game and run it.
            using (var game = new Central())
                game.Run();
        }
    }
}