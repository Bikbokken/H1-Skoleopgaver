﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal interface IMachine
    {
        void RemoveOneAmount(int slot);
        List<Item> GetAllItems();
    }
}
