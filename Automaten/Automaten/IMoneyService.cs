using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal interface IMoneyService
    {

        double GetCurrentMoney();
        void AddMoney(double amount);
    }
}
