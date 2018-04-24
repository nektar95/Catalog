using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock2.BO
{
    public class Tea : ITea
    {
        public IProducer Producer { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public TeaType Type { get; set; }
        public int Temperature { get; set; }
    }
}
