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


        private void ScrambleHeros()
        {
            Random randomNum = new Random();
            _heroList = _heroList.OrderBy(a => randomNum.Next()).ToList();
           
        }

        private int GetAttackPoints(Hero hero, bool rightHand)
        {
            int attack = 0;
            Random r = new Random();
            if (hero.GetType() == typeof(Karl))
            {
                if (rightHand)
                {
                    attack = hero.AttackRange.Start;
                }
                else
                {
                    attack = hero.AttackRange.End;
                }
            }
 
            else
            {
                attack = r.Next(hero.AttackRange.Start, hero.AttackRange.End);
            }

            return attack;
        }

        public Hero BattleHeros(List<KeyValuePair<int, Hero>> heros)
        {
            KeyValuePair<int, Hero> first = heros.First();
            KeyValuePair<int, Hero> last = heros.Last();

            int attack = 0;
            Random r;
            bool rightHand = false;
            int loopTimes = 0;
            while (first.Value.HitPoints >= 0 && last.Value.HitPoints >= 0)
            {

                attack = GetAttackPoints(first.Value, rightHand);

                    
                if(first.Value.GetType() == typeof(Tiger)) {
                    if(loopTimes < 9)
                    {
                        first.Value.IncrementPoints(3);
                    }
                } 
              
                last.Value.Attack(attack);


                //////


                attack = GetAttackPoints(last.Value, rightHand);


                if (last.Value.GetType() == typeof(Tiger))
                {
                    if (loopTimes < 9)
                    {
                        last.Value.IncrementPoints(3);
                    }
                }


                first.Value.Attack(attack);

                //////

                if (rightHand)
                {
                    rightHand = false;
                }
                else
                {
                    rightHand = true;
                }

            loopTimes++;

            }
            if (first.Value.HitPoints > last.Value.HitPoints)
            {
                return last.Value; // Return the losing hero
            } else
            {
                return first.Value; // Return the losing hero
            }



        }

        public List<Hero> GetHeros()
        {
            return _heroList;
        }

       
        public int HeroCount()
        {
            return _heroList.Count;
        }

        public Arena() {
            _heroList = new List<Hero>
            {
                new Harry(120),
                new Dino(70),
                new Karl(90),
                new Gunner(90),
                new Mikkel(40),
                new Tiger(35),
                new Ivan(70),
                new Egon(90),
            };
            ScrambleHeros();
        }

    }
}
