using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOMock2
{
    public class DAO : IDAO
    {
        private List<IProducer> _producers;
        private List<ITea> _teas;

        public DAO()
        {
            _producers = new List<IProducer>()
            {
                new BO.Producer() {Name="Herbatex" , Country="Germany",Url="www.herbatex.de", Number = "16525563"},
                new BO.Producer() {Name="Herbapol" , Country="Vietnam",Url="www.herbapol.ua", Number = "46515567"},
                new BO.Producer() {Name="Saga" , Country="India",Url="www.saga.pl", Number = "98745567"},
                new BO.Producer() {Name="Imperial Royal Tea Ltd." , Country="Poland",Url="www.royal.tea", Number = "76545567"}
            };

            _teas = new List<ITea>()
            {
                new BO.Tea() {Name="White Power",Producer = _producers[0], ProductionYear = 2018, Type = Core.TeaType.White,Temperature = 65},
                new BO.Tea() {Name="Green Magic",Producer = _producers[1], ProductionYear = 1918, Type = Core.TeaType.Green, Temperature = 98},
                new BO.Tea() {Name="Classic Green",Producer = _producers[2], ProductionYear = 2015, Type = Core.TeaType.Green, Temperature = 75},
                new BO.Tea() {Name="English Black Lemon",Producer = _producers[3], ProductionYear = 2011, Type = Core.TeaType.Black, Temperature = 100}
            };
        }

        public IEnumerable<ITea> GetAllTeas()
        {
            return _teas;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }
    }
}
