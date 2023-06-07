using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class GuiService : IGuiService
    {

        public void ShowIncorrectPools()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du har ikke et validt antal af Pools! Der skal være 2*pools antal af Heros! Ikke mere eller mindre!");
        }

        public void ShowWinner(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("VINDEREN ER:");
            Console.WriteLine(hero);
            Console.WriteLine("");
        }

        public void ShowNextRound()
        {
            Console.Clear();
            Console.WriteLine("==========");
            Console.WriteLine("NÆSTE RUNDE");
            Console.WriteLine("==========");
        }

        public void ShowScoreboard(List<KeyValuePair<int, Hero>> scoreboard)
        {
            Console.WriteLine("Superhelte i samme gruppe kommer itl at kæmpe mod hinanden!");
            Console.WriteLine("Gruppe : Hero");
            foreach (KeyValuePair<int, Hero> item in scoreboard)
            {
                Console.Write(item.Key + " => " + item.Value);
                Console.WriteLine();
            }
        }

        public void ShowWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("         Fight Arena");
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
