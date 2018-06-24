using BLC;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ITea> _products;
        public ObservableCollection<ITea> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        static public DataProvider _provider;

        public MainWindow()
        {
            if (_provider == null)
                _provider = new DataProvider("DAOMock");
            //_products = new ObservableCollection<ITea>(dp.getTeas);
            InitializeComponent();
        }
    }
}
