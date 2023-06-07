using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class GuiService : IGuiService
    {

        /// <summary>
        /// Show an error message with the incorrect number of pools.
        /// </summary>
        public void ShowIncorrectPools()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set the consolecolor to red
            Console.WriteLine("Du har ikke et validt antal af Pools! Der skal være 2*pools antal af Heros! Ikke mere eller mindre!");
        }

        /// <summary>
        /// Show the winner, which is the parameter provided.
        /// </summary>
        public void ShowWinner(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("VINDEREN ER:");
            Console.WriteLine(hero);
            Console.WriteLine("");
        }

        /// <summary>
        /// Shows a next round banner
        /// </summary>
        public void ShowNextRound()
        {
            Console.Clear();
            Console.WriteLine("==========");
            Console.WriteLine("NÆSTE RUNDE");
            Console.WriteLine("==========");
        }

        /// <summary>
        /// Shows the current scoreboard, which is the parameter provided.
        /// </summary>
        public void ShowScoreboard(List<KeyValuePair<int, Hero>> scoreboard)
        {
            Console.WriteLine("Superhelte i samme gruppe kommer itl at kæmpe mod hinanden!");
            Console.WriteLine("Gruppe : Hero");
            foreach (KeyValuePair<int, Hero> item in scoreboard) // Loop thorugh every item in the scoreboard.
            {
                Console.Write(item.Key + " => " + item.Value);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Show the welcome banner.
        /// </summary>
        public void ShowWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set the console color to red.
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("         Fight Arena");
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.ForegroundColor = ConsoleColor.Gray; // Set the console color to gray.
        }
    }
}
