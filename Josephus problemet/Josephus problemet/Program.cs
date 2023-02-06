

using Microsoft.VisualBasic;
using System;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;

class Program
{

    static void Main(string[] args)
    {
        int interval = 3;
        int soilders = 41;
        int index = 0;

        interval--;
        
        List<int> soilderarray = new List<int>();


        for (int i = 1; i <= soilders; i++)
        {
            soilderarray.Add(i);
        }
            

        while(soilderarray.Count != 1)
        {
            index = (index + interval) % soilderarray.Count;
            soilderarray.RemoveAt(index);

        };
        Console.WriteLine(soilderarray[0]);

        
    }
   
    
}
