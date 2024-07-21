using System;

namespace Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            ConsoleGUI gui = new ConsoleGUI(manager);
            gui.Run();
        }
    }
}
