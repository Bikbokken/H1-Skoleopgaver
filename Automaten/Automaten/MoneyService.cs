using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class MoneyService : IMoneyService
    {
        private double _currentMoney = 0;

        public double GetCurrentMoney()
        {
            return _currentMoney;
        }

        public void AddMoney(double amount)
        {
            _currentMoney += amount;
        }

    }
}
