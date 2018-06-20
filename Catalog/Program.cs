using System;
using BLC;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BLC.DataProvider dataProvider = new BLC.DataProvider("DAOMock");

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
