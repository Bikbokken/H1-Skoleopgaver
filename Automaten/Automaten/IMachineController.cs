using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal interface IMachineController
    {
        void ShowAllItems();
        bool PromptOrder();
        void ShowSelectedItem();
        void ConfirmOrder();
        void ShowMachineStatus();

    }
}
