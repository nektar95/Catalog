using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock.BO
{
    public class Producer : IProducer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Url { get; set; }
        public string Number { get; set; }
    }
}
