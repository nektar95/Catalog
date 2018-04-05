using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock
{
    public class DAO : IDAO
    {
        private List<IProducer> producers;
        private List<ITea> teas;

        public DAO()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Name="Herbatex" , Country="Germany",Url="www.herbatex.de", Number = "16525563"},
                new BO.Producer() {Name="Herbapol" , Country="Vietnam",Url="www.herbapol.ua", Number = "46515567"},
                new BO.Producer() {Name="Saga" , Country="India",Url="www.saga.pl", Number = "98745567"},
                new BO.Producer() {Name="Imperial Royal Tea Ltd." , Country="Poland",Url="www.royal.tea", Number = "76545567"}
            };

            teas = new List<ITea>()
            {
                new BO.Tea() {Name="White Power",Producer = producers[0], ProductionYear = 2018, Type = Core.TeaType.White,Temperature = 65},
                new BO.Tea() {Name="Green Magic",Producer = producers[1], ProductionYear = 1918, Type = Core.TeaType.Green, Temperature = 98},
                new BO.Tea() {Name="Classic Green",Producer = producers[2], ProductionYear = 2015, Type = Core.TeaType.Green, Temperature = 75},
                new BO.Tea() {Name="English Black Lemon",Producer = producers[3], ProductionYear = 2011, Type = Core.TeaType.Black, Temperature = 100}
            };
        }

        public IEnumerable<ITea> GetAllTeas()
        {
            return teas;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }
    }
}
