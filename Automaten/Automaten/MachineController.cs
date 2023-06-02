using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class MachineController : IMachineController
    {
        private IGuiService _guiService;
        private IMachine _machine;
        private IMoneyService _moneyService;

        private int selectedSlot = -1;
        private List<Item> _items;

        public void ConfirmOrder()
        {
            bool hasCancelled = _guiService.ConfirmOrder(selectedSlot);
            if(!hasCancelled)
            {
                MakeOrder();
            } else
            {
                ResetOrder();
            }
        }

        private void MakeOrder()
        {
            _guiService.ShowOrder(selectedSlot);
            _machine.RemoveOneAmount(selectedSlot);
            _moneyService.AddMoney(_items[selectedSlot].Price);
            ResetOrder();
        }

        public void ShowMachineStatus()
        {
            _guiService.ShowMachineStatus(_moneyService.GetCurrentMoney());
        }

        private void ResetOrder()
        {
            selectedSlot = -1;
            FetchProducts();
        }

        public void ShowAllItems()
        {
            _guiService.ShowItems();
        }

        public bool PromptOrder()
        {
            int slot = _guiService.PromptOrder();
            if (slot != -1)
            {
                selectedSlot = slot;
                return true;
            } 
            return false;
        }

        public void ShowSelectedItem()
        {
            _guiService.ShowItem(_items[selectedSlot]);
        }

        private void FetchProducts()
        {
            _items = _machine.GetAllItems();
            _guiService.SetItems(_items);
        }

        public MachineController(IGuiService guiService, IMachine machine, IMoneyService moneyService)
        {
            this._guiService = guiService;
            this._machine = machine;
            this._moneyService = moneyService;
            FetchProducts();
        }
    }
}
