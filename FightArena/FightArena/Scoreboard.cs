using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    
    internal class Scoreboard : IScoreboard
    {
        private List<Hero> _heros;
        private List<KeyValuePair<int, Hero>> _scoreboard = new List<KeyValuePair<int, Hero>>();

        public void GenerateGroups()
        {
            int num = 1;
            int loopTime = 0;
            for(int i=0; i < _heros.Count(); i++)
            {
                loopTime++;
                _scoreboard.Add(new KeyValuePair<int, Hero>(num, _heros[i]));
                if(loopTime == 2)
                {
                    num++;
                    loopTime = 0;
                }
            }

        }

        public void RearrangeScoreboard() {
            List<KeyValuePair<int, Hero>> _tmpScoreboard = new List<KeyValuePair<int, Hero>>();

            int num = 1;
            int loopTime = 0;
            for (int i = 0; i < _scoreboard.Count; i++)
            {
                loopTime++;
                _tmpScoreboard.Add(new KeyValuePair<int, Hero>(num, _scoreboard[i].Value));
                if (loopTime == 2)
                {
                    num++;
                    loopTime = 0;
                }
            }

            _scoreboard = _tmpScoreboard;
        }

        public int ScoreboardCount()
        {
            return _scoreboard.Count();
        }

        public List<KeyValuePair<int, Hero>> GetScoreboard()
        {
            return _scoreboard;
        }

        public void DeleteFromScoreboard(Hero hero, int group)
        {
            _scoreboard.RemoveAll(x => x.Key == group && x.Value == hero);
        }

        public List<KeyValuePair<int, Hero>> GetGroup(int id)
        {
            return  _scoreboard.Where(x => x.Key == id).ToList();
        }

        public List<KeyValuePair<int, Hero>> GetPools() { return _scoreboard; }


        public Scoreboard(List<Hero> heros)
        {
            _heros = heros;
        }
    }
}
