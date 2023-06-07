using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal interface IGuiService
    {
        public void ShowIncorrectPools();
        public void ShowWelcome();
        public void ShowScoreboard(List<KeyValuePair<int, Hero>> scoreboard);
        public void ShowNextRound();
        public void ShowWinner(Hero hero);

    }
}
