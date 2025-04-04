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
            int[] mas = {0, 1, 2, 0, 1, 2, 1, 2};
            foreach (int a in ClassSort.FourSort(mas, true))
                Console.Write("{0} ", a);
        }
    }
}
