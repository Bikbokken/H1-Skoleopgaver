using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToOOP
{
    internal class Interface
    {
        interface IEngine
        {
            double calculateHP();
        }

        interface IElectricEngine : IEngine
        {
            double LoadingCapacity();
        }

        class Test : IElectricEngine
        {
            public double calculateHP() { return 2.2; }
            public double LoadingCapacity() { return 2.2; }
        }
    }
}
