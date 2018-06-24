using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<ITea> GetAllTeas();
        IEnumerable<IProducer> GetAllProducers();

        IProducer AddNewProducer();
        ITea AddNewTea();

        void SaveTea(ITea t);
        void SaveProducer(IProducer p);

        void DeleteTea(ITea t);
        void DeleteProducer(IProducer p);
    }
}
