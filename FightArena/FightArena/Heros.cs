using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class Range
    {
        public int Start;
        public int End;
        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
    internal abstract class Hero
    {
        public virtual int HitPoints { get; set;  }
        public abstract Range AttackRange { get; }
        public abstract Range Defence { get; }

        public void Attack(int num)
        {
            Random r = new Random(); // Generate a random
            int defence = r.Next(Defence.Start, Defence.End); // Get a random defence number

            if (defence - num > 0) // If defence - num is greather than 0
            {
                HitPoints -= (defence - num); // Subtract hitpoints with defense - num
            }
        }

        /// <summary>
        /// Incremenets the number of points in the object
        /// </summary>
        public void IncrementPoints(int num)
        {
            HitPoints += num; // Increment the hitpoints of the object.
        }

        


    }
    internal sealed class Harry : Hero
    {
        public override Range AttackRange { get { return new Range(2,2); } }
        public override Range Defence { get { return new Range(5,5); } }

        public Harry(){
            HitPoints = 120;
        } 
    }

    internal sealed class Dino : Hero
    {
        public override Range AttackRange { get { return new Range(6, 8); } }
        public override Range Defence { get { return new Range(2, 8); } }
        public Dino()
        {
            HitPoints = 70;
        }

    }

    internal sealed class Karl : Hero
    {
        public override Range AttackRange { get { return new Range(2, 5); } }
        public override Range Defence { get { return new Range(3, 3); } }
        public Karl()
        {
            HitPoints = 90;
        }

    }

    internal sealed class Gunner : Hero
    {
        public override Range AttackRange { get { return new Range(1, 13); } }
        public override Range Defence { get { return new Range(5, 5); } }
        public Gunner()
        {
            HitPoints = 90;
        }
    }

    

    internal sealed class Mikkel : Hero
    {
        public override Range AttackRange { get { return new Range(9, 9); } }
        public override Range Defence { get { return new Range(9, 9); } }
        public Mikkel()
        {
            HitPoints = 40;
        }

    
    }

    internal sealed class Tiger : Hero
    {
        public override Range AttackRange { get { return new Range(3, 6); } }
        public override Range Defence { get { return new Range(4, 4); } }
        public Tiger()
        {
            HitPoints = 35;
        }

    }

    internal sealed class Ivan : Hero
    {
        public override Range AttackRange { get { return new Range(6, 6); } }
        public override Range Defence { get { return new Range(8, 8); } }
        public Ivan()
        {
            HitPoints = 70;
        }

    }

    internal sealed class Egon : Hero
    {
        public int WeightKilos { get { return 300;  } }
        public override Range AttackRange { get { return new Range(5, 11); } }
        public override Range Defence { get { return new Range(4, 4); } }
        public Egon()
        {
            HitPoints = 90;
        }

    }

}
