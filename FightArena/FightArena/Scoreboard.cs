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

        /// <summary>
        /// Generate the groups with the heros in the game.
        /// </summary>
        private List<KeyValuePair<int, Hero>> GenerateGroups(List<Hero> heros)
        {
            List<KeyValuePair<int, Hero>> _tmpScoreboard = new List<KeyValuePair<int, Hero>>();

            int num = 1;
            int loopTime = 0;
            for(int i=0; i < heros.Count(); i++) // Loop through every hero.
            {
                loopTime++; // Increment the loop by 1
                _tmpScoreboard.Add(new KeyValuePair<int, Hero>(num, heros[i])); // Add an entry in the scoreboard with the group number and the hero.
                if(loopTime == 2) // If it is the second loop
                {
                    num++; // Increment the number
                    loopTime = 0; // Reset the loop time
                }
            }

            return _tmpScoreboard;

        }

        /// <summary>
        /// Rearrange the scoreboard, so the new entries gets their own groups
        /// </summary>
        public void RearrangeScoreboard() {

            List<Hero> tmpHeros = new List<Hero>();

            foreach(KeyValuePair<int, Hero> hero in _scoreboard)
            {
                tmpHeros.Add(hero.Value);
            }

            _scoreboard = GenerateGroups(tmpHeros);
        }

        /// <summary>
        /// Returns the number of entries in the scoreboard
        /// </summary>
        public int ScoreboardCount()
        {
            return _scoreboard.Count();
        }

        /// <summary>
        /// Returns the scoreboard
        /// </summary>
        public List<KeyValuePair<int, Hero>> GetScoreboard()
        {
            return _scoreboard;
        }


        /// <summary>
        /// Delete all entries from the scoreboard than contains the group and hero as key and value.
        /// </summary>
        public void DeleteFromScoreboard(Hero hero, int group)
        {
            _scoreboard.RemoveAll(x => x.Key == group && x.Value == hero);
        }

        /// <summary>
        /// Returns the heros in a specific group 
        /// </summary>
        public List<KeyValuePair<int, Hero>> GetGroup(int id)
        {
            return  _scoreboard.Where(x => x.Key == id).ToList();
        }


        // Constructor
        public Scoreboard(List<Hero> heros)
        {
            _heros = heros;
            _scoreboard = GenerateGroups(heros);
        }
    }
}
