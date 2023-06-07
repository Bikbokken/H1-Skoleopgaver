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
        public virtual Range AttackRange { get; set; }
        public virtual Range Defence { get; set; }

        public void Attack(int num)
        {
            Random r = new Random();
            int defence = r.Next(Defence.Start, Defence.End);

            if (defence - num > 0)
            {
                HitPoints = HitPoints - (defence - num);
            }
        }

        public void IncrementPoints(int num)
        {
            HitPoints += num;
        }

        public Hero(int hitpoints) {
            HitPoints = hitpoints;
        }


    }
    internal sealed class Harry : Hero
    {
        public override Range AttackRange { get { return new Range(2,2); } }
        public override Range Defence { get { return new Range(5,5); } }

        public Harry(int hitpoints) : base(hitpoints) { } 
    }

    internal sealed class Dino : Hero
    {
        public override Range AttackRange { get { return new Range(6, 8); } }
        public override Range Defence { get { return new Range(2, 8); } }
        public Dino(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Karl : Hero
    {
        public override Range AttackRange { get { return new Range(2, 5); } }
        public override Range Defence { get { return new Range(3, 3); } }
        public Karl(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Gunner : Hero
    {
        public override Range AttackRange { get { return new Range(1, 13); } }
        public override Range Defence { get { return new Range(5, 5); } }
        public Gunner(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Mikkel : Hero
    {
        public override Range AttackRange { get { return new Range(9, 9); } }
        public override Range Defence { get { return new Range(9, 9); } }
        public Mikkel(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Tiger : Hero
    {
        public override Range AttackRange { get { return new Range(3, 6); } }
        public override Range Defence { get { return new Range(4, 4); } }
        public Tiger(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Ivan : Hero
    {
        public override Range AttackRange { get { return new Range(6, 6); } }
        public override Range Defence { get { return new Range(8, 8); } }
        public Ivan(int hitpoints) : base(hitpoints) { }

    }

    internal sealed class Egon : Hero
    {
        public int WeightKilos { get { return 300;  } }
        public override Range AttackRange { get { return new Range(5, 11); } }
        public override Range Defence { get { return new Range(4, 4); } }
        public Egon(int hitpoints) : base(hitpoints) { }

    }

}
