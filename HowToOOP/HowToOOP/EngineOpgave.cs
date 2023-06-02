using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToOOP
{
    internal class EngineOpgave
    {
        abstract class Engine
        {
            public abstract double calculateHP();
        }

        class ElectricalEngine : Engine
        {
            public virtual double LoadingCapacity() { return 200;  }
        }

        abstract class CompositionEngine : Engine
        {
            public virtual double MaxNPM() { return 700;  }
            public virtual double calculateCarbonOxide(double engineSize) { return engineSize * 0.0078;  }
        }

        sealed class BigElectricalEngine : ElectricalEngine
        {
            public override double calculateHP() { return 1020;  }
            public override double LoadingCapacity() { return 400; }
        }

        sealed class MediumElectricalEngine : ElectricalEngine
        {
            public override double calculateHP() { return 655; }
            public override double LoadingCapacity() { return 345; }
        }

        class SmallElectricalEngine : ElectricalEngine
        {
            public override double calculateHP() { return 248; }
        }

        abstract class GasolineEngine : CompositionEngine { 
            public override double MaxNPM() { return 998;  }
            public override double calculateCarbonOxide(double engineSize) { return engineSize * 0.098 }
        }

        abstract class DieselEngine: CompositionEngine
        {
            public override double MaxNPM() { return 1303;  }
            public override double calculateCarbonOxide(double engineSize) { return engineSize * 2.098;  }
        }

        sealed class Engine1000CCM: GasolineEngine
        {
            public override double MaxNPM(){ return 598;  }
      
        }

    }
}
