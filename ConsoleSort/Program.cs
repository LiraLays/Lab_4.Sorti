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
            int[] mas = { 0,0,0,0,1,1,1,1};
            foreach (int a in ClassSort.TwoSort(mas, true))
                Console.Write("{0} ", a);
        }
    }
}
