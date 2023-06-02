using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class MoneyService : IMoneyService, IMoneyAdmin
    {
        private double _currentMoney = 0;

        public double GetCurrentMoney()
        {
            return _currentMoney;
        }

        public void RemoveCash(int amount) { 
            _currentMoney = amount; 
        }

        public void AddMoney(double amount)
        {
            _currentMoney += amount;
        }

    }
}
