using Collections.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> l = new MyList<int>();
            for (int i = 0; i < 10; i++)
                l.Add(i);
            foreach (int x in l)
                Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
