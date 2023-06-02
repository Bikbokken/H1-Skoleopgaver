using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class AdminController : IAdminController
    {
        private IMoneyAdmin _moneyAdmin { get; }
        private IMachineAdmin _machineAdmin { get; }

        public void RemoveCash(int amount)
        {
            _moneyAdmin.RemoveCash(amount);
        }

        public void CreateItem(Item item)
        {
            _machineAdmin.CreateItem(item);
        }


        public Item ReadItem(byte slot)
        {
            return _machineAdmin.ReadItem(slot);
        }

        public void UpdateItem(byte slot, Item item)
        {
            _machineAdmin.UpdateItem(slot, item);   
        }

        public void DeleteItem(byte slot)
        {
            _machineAdmin.DeleteItem(slot);
        }

        public void UpdateAmount(byte slot, byte amount)
        {
            _machineAdmin.UpdateAmount(slot, amount);  
        }


        public AdminController(IMoneyAdmin moneyAdmin, IMachineAdmin machineAdmin)
        {
            _moneyAdmin = moneyAdmin;
            _machineAdmin = machineAdmin;
        }
    }
}
