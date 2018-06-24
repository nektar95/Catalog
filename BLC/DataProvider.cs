using Interfaces;
using DAOMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using BLC.Properties;

namespace BLC
{
    public class DataProvider
    {
        private Settings _settings = new Settings();

        public IDAO _DAO { get; set;}

        public IEnumerable<ITea> getTeas
        {
            get { return _DAO.GetAllTeas(); }
        }

        public IEnumerable<IProducer> getProducers
        {
            get { return _DAO.GetAllProducers(); }
        }

        public DataProvider(string databaseName)
        {
            var path = Directory.GetCurrentDirectory() + string.Format(@"\{0}.dll", databaseName);
            var dll = Assembly.LoadFrom(path);

            foreach (var type in dll.GetTypes())
            {
                if (type.GetInterfaces().Any(i => i == typeof(IDAO)))
                {
                    _DAO = (IDAO)Activator.CreateInstance(type, new object[] { });
                    break;
                }
            }
        }

        public ITea addNewTea()
        {
            return _DAO.AddNewTea();
        }

        public IProducer addNewProducer()
        {
            return _DAO.AddNewProducer();
        }

        public void saveProduct(ITea t)
        {
            _DAO.SaveTea(t);
        }

        public void SaveProducer(IProducer p)
        {
            _DAO.SaveProducer(p);
        }

        public void DeleteProduct(ITea t)
        {
            _DAO.DeleteTea(t);
        }

        public void DeleteProducer(IProducer p)
        {
            _DAO.DeleteProducer(p);
        }
    }
}
