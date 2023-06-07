using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class Arena : IArena
    {
        private List<Hero> _heroList;


        /// <summary>
        /// Scramble all the heros, so they come in a random order.
        /// </summary>
        private void ScrambleHeros()
        {
            Random randomNum = new Random(); // Create a random
            _heroList = _heroList.OrderBy(a => randomNum.Next()).ToList(); // Using the LINQ function OrderBy, we can sort the List.
           
        }

        /// <summary>
        /// Get Attack points calculates the points the hero should attack with.
        /// </summary>
        private int GetAttackPoints(Hero hero, bool rightHand)
        {
            int attack = 0;
            Random r = new Random();
            if (hero.GetType() == typeof(Karl)) // If the Hero Parameter is the Class "Karl"
            {
                if (rightHand) // If the Parameter rightHand is true
                {
                    attack = hero.AttackRange.Start; // Set the Attack variable to the first value in the range.
                }
                else
                {
                    attack = hero.AttackRange.End; // Set the Attack variable to the last value in the range.
                }
            }
 
            else // If the Object is not the type Karl.
            {
                attack = r.Next(hero.AttackRange.Start, hero.AttackRange.End); //Generate a random attack value from the Start and End range. 
            }

            return attack;
        }

        /// <summary>
        /// Battleheros takes to heros in a List, and fights them. Then returns the losing one.
        /// </summary>
        public Hero BattleHeros(List<KeyValuePair<int, Hero>> heros)
        {
            KeyValuePair<int, Hero> first = heros.First(); // Set the first value in the list to first.
            KeyValuePair<int, Hero> last = heros.Last(); // Set the last value in the list to the last.

            int attack = 0;
            Random r;
            bool rightHand = false;
            int loopTimes = 0;
            while (first.Value.HitPoints >= 0 && last.Value.HitPoints >= 0) // While the hitpoints on both heros is over 0.
            {

                // FIRST HERO ATTACKING

                attack = GetAttackPoints(first.Value, rightHand); // Get the attackpoints of the first hero

                    
                if(first.Value.GetType() == typeof(Tiger)) { // IF the first hero is class Tiger.
                    if(loopTimes < 9) // If the loop has been run less than 9 times.
                    {
                        first.Value.IncrementPoints(3); // Increment the points of the hero with 3.
                    }
                } 
              
                last.Value.Attack(attack); // Attack the second hero with the attackpoints gained from the first hero.


                
                // SECOND HERO ATTACKING


                attack = GetAttackPoints(last.Value, rightHand); // Get the attackpoints of the last hero.


                if (last.Value.GetType() == typeof(Tiger)) // If the second hero is the class Tiger
                {
                    if (loopTimes < 9) // If the loop has been run less than 9 times.
                    {
                        last.Value.IncrementPoints(3); // Increment the points of the hero with 3.
                    }
                }


                first.Value.Attack(attack); // Attack the first hero with the attackpoints gained from the second hero.

                //////

                if (rightHand) // If the bool rightHand is true.
                {
                    rightHand = false; // set to false
                }
                else
                {
                    rightHand = true; // Set to true
                }

            loopTimes++; // Increment loopTimes with 1.

            }
            if (first.Value.HitPoints > last.Value.HitPoints) // If the first hero won
            {
                return last.Value; // Return the losing hero
            } else // If the last hero win
            {
                return first.Value; // Return the losing hero
            }



        }

        /// <summary>
        /// GetHeros returns the list of Heros.
        /// </summary>
        public List<Hero> GetHeros()
        {
            return _heroList;
        }

        /// <summary>
        /// HeroCount returns the count of heros in the list.
        /// </summary>
        public int HeroCount()
        {
            return _heroList.Count;
        }

        public Arena() { // Constructor
            _heroList = new List<Hero> // Create all the heros.
            {
                new Harry(),
                new Dino(),
                new Karl(),
                new Gunner(),
                new Mikkel(),
                new Tiger(),
                new Ivan(),
                new Egon(),
            };
            ScrambleHeros();
        }

    }
}
