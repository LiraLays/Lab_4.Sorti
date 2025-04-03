using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrarySort;
namespace ConsoleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mas = { 9 };//, 8, 7, 6, 5, 4, 5, 6, 7};
            foreach (int a in ClassSort.CountSort(mas, true))
                Console.Write("{0} ", a);
        }
    }
}
