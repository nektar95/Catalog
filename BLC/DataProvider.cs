using Interfaces;
using DAOMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLC
{
    public class DataProvider
    {
        public IDAO DAO { get; set;}
      
        public IEnumerable<ITea> getTeas
        {
            get { return DAO.GetAllTeas(); }
        }

        public IEnumerable<IProducer> getProducers
        {
            get { return DAO.GetAllProducers(); }
        }

        public DataProvider()
        {
            DAO = (IDAO) new DAOMock.DAO();
        }
    }
}
