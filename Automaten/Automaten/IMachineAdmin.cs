using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal interface IMachineAdmin : IMachine
    {
        void CreateItem(Item item);
        Item ReadItem(byte slot);
        void UpdateItem(byte lsot, Item item);
        void DeleteItem(byte slot);
        void UpdateAmount(byte slot, byte number);
        void RemoveOneAmount(int slot);
    }
}
