using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class MachineController : IMachineController
    {
        private IGuiService _guiService { get; }
        private IMachine _machine { get; }
        private IMoneyService _moneyService { get; }

        private int selectedSlot = -1;
        private List<Item> _items;

        public void ConfirmOrder()
        {
            bool hasCancelled = _guiService.ConfirmOrder(selectedSlot); // Prompt the user for confirmation
            if(!hasCancelled)
            {
                MakeOrder(); // Make the order if the order is confirmed
            } else
            {
                ResetOrder(); // Reset the order if not confirmed
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
            if (slot != -1) // Check if the prompt order is not invalid (PromptOrder() returns -1 if the order is not valid
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
            _items = _machine.GetAllItems(); // Contact the machine and get all the items and set the local cache
            _guiService.SetItems(_items); // Set the local cache of the guiService 
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
