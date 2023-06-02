using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal interface IGuiService
    {
        void ShowItems();
        int PromptOrder();
        void ShowItem(Item item);
        void SetItems(List<Item> items);
        bool ConfirmOrder(int selectedItem);
        void ShowOrder(int selectedItem);
        void ShowMachineStatus(double money);

    }
}
