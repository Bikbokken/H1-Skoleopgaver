using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal interface IArena
    {
        public int HeroCount();
        public List<Hero> GetHeros();
        public Hero BattleHeros(List<KeyValuePair<int, Hero>> heros);

    }
}
