using Challenge2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace JunkYard01
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Claim> line = new Queue<Claim>();
            line.Enqueue(new Claim("1", ClaimType.Car, "...", 22.25d, new DateTime(2012, 8, 20), new DateTime(2020, 12, 8), true));
            line.Enqueue(new Claim("2", ClaimType.Car, "...", 22.25d, new DateTime(2012, 8, 20), new DateTime(2020, 12, 8), true));
            line.Enqueue(new Claim("3", ClaimType.Car, "...", 22.25d, new DateTime(2012, 8, 20), new DateTime(2020, 12, 8), true));

            while (line.Count>0)
            {
                var itemToDeque = line.Dequeue();
                Console.WriteLine(itemToDeque.ClaimType);
            }

            Console.ReadKey();
        }
    }
}
