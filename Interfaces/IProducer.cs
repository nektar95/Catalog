using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        string Country { get; set; }
        string Number { get; set; }
        string Url { get; set; }
    }
}
