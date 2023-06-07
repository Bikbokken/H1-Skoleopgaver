using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal interface IScoreboard
    {
        public List<KeyValuePair<int, Hero>> GetPools();
        public void GenerateGroups();
        public void DeleteFromScoreboard(Hero hero, int group);
        public List<KeyValuePair<int, Hero>> GetGroup(int id);
        public List<KeyValuePair<int, Hero>> GetScoreboard();
        public int ScoreboardCount();
        public void RearrangeScoreboard();

    }
}
