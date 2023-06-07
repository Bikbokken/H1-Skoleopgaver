using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal interface IArenaController
    {
        public bool Initialize(byte pools);
        public void StartBattle();
    }
}
