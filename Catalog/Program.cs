using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogNew
{
    class Program
    {
        static void Main(string[] args)
        {
            BLC.DataProvider dataProvider = new BLC.DataProvider();

            Console.WriteLine("Producenci herbaty:");

            foreach ( var p in dataProvider.getProducers)
            {
                Console.WriteLine( p.Name +" from " + p.Country);
            }

            Console.WriteLine("Herbaty:");

            foreach (var p in dataProvider.getTeas)
            {
                Console.WriteLine(p.Name);
            }
            Console.Read();
        }
    }
}
