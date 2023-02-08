using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Køen;

namespace Køen
{


    /// <summary>
    /// Queue Controller controlling the queue
    /// </summary>
    public class QueueController
    {
        public Queue<Guest> guests = new Queue<Guest>(); 
        
        public void AddGuest(Guest guest)
        {
            guests.Enqueue(guest);
        }

        public Guest NextInLine()
        {
            return guests.Peek();
        }

        public void RemoveNextInline()
        {
            guests.Dequeue();
        }

    }
}
