

using System;
using System.ComponentModel.DataAnnotations;

public class Program
{
    static void Main(string[] args)
    {

        int[,] salesPerYear = { { 2009, 175134 }, { 2010, 175388 }, { 2011, 172818 }, { 2012, 142709 }, { 2013, 151437 }, { 2014, 152620 }, { 2015, 150979 }, { 2016, 152210 }, { 2017, 149450 }, { 2018, 154398 }, { 2019, 150160 } };


        const int max = 175388;
        byte maxStar = 100;

        // for (int k = 0; k < salesPerYear.GetLength(0); k++)
        //{
        //   int value = salesPerYear[k, 1];
        //  int stars = maxStar * value / max;
        // Console.WriteLine(new string('*', stars));
        //}

        //B
        //for (int i = 0; i < salesPerYear.GetLength(0); i++)
        //{
        //  if (salesPerYear[i, 0] == 2014)
        //{
        //  salesPerYear[i, 1] = salesPerYear[i, 1] + 35432;
        //}
        //}

        //C 

        for(int x = 0; x < salesPerYear.GetLength(0) -1; x++)
        {
            if (salesPerYear[x, 1] < salesPerYear[x +1, 1])
            {
                Console.WriteLine("Elementet en foran er højere end det nuværende");
                int old = salesPerYear[x +1, 1];
                int old_name = salesPerYear[x +1, 0];
                salesPerYear[x + 1, 1] = salesPerYear[x, 1];
                salesPerYear[x + 1, 0] = salesPerYear[x, 0];
                salesPerYear[x, 1] = old;
                salesPerYear[x, 0] = old_name;
            }
        }
    }
}
