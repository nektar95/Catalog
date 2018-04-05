using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITea
    {
        IProducer Producer { get; set; }
        string Name { get; set; }
        int ProductionYear { get; set; }
        int Temperature { get; set; }
        TeaType Type { get; set; }
    }
}
