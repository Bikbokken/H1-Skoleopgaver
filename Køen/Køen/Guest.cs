using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Køen
{

    /// <summary>
    /// Guest Object
    /// </summary>
    public class Guest
    {
        public Guest(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public byte Age { get; set; }
    }
}
