using Interfaces;
using DAOMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BLC.Properties;

namespace BLC
{
    public class DataProvider
    {
        private Settings _settings = new Settings();

        public IDAO DAO { get; set;}

        public IEnumerable<ITea> getTeas
        {
            get { return DAO.GetAllTeas(); }
        }

        public IEnumerable<IProducer> getProducers
        {
            get { return DAO.GetAllProducers(); }
        }

        private void _loadChosenDatabase()
        {
            Assembly assemblyDAO = Assembly.UnsafeLoadFrom(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString()).ToString() + "/" + _settings.mockName + ".dll");
            Type typeDAO = assemblyDAO.GetType( _settings.mockName + ".DAO");
            ConstructorInfo constructorInfo = typeDAO.GetConstructor(new Type[] { });
            var temp = constructorInfo.Invoke(new object[] { });
            DAO = (IDAO)temp;
        }

        public DataProvider()
        {
            //DAO = (IDAO) new DAOMock.DAO();
            _loadChosenDatabase();
        }
    }
}
