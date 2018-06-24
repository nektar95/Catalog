using BLC;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GUI.ViewModels
{
    public class TeasListViewModel : ViewModelBase
    {
        public ObservableCollection<TeaViewModel> Teas { get; set; } = new ObservableCollection<TeaViewModel>();

        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private DataProvider _provider;

        public string FilterValue { get; set; }

        public TeasListViewModel()
        {
            _provider = MainWindow._provider;
            OnPropertyChanged("Teas");
            GetAllTeas();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Teas);
            _filterDataCommand = new RelayCommand(param => this.FilterData());

            _addNewTeaCommand = new RelayCommand(param => this.AddNewTea(), param => this.CanAddNewTea());

            _saveTeaCommand = new RelayCommand(param => this.SaveTea(), param => this.CanSaveTea());

            _deleteTeaCommand = new RelayCommand(param => this.DeleteTea(), param => this.CanDeleteTea());
        }

        private void GetAllTeas()
        {
            foreach (var tea in _provider.getTeas)
            {
                Teas.Add(new TeaViewModel(tea, (List<IProducer>)_provider.getProducers));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (c) => ((TeaViewModel)c).Name.Contains(FilterValue);
            }
        }

        private TeaViewModel _editedTea;
        public TeaViewModel EditedTea
        {
            get => _editedTea;
            set
            {
                _editedTea = value;
                OnPropertyChanged(nameof(EditedTea));
            }
        }

        private void AddNewTea()
        {
            EditedTea = new TeaViewModel(_provider.addNewTea(), (List<IProducer>)_provider.getProducers);
            EditedTea.Name = "";
            EditedTea.Validate();
        }

        private RelayCommand _addNewTeaCommand;

        public RelayCommand AddNewTeaCommand
        {
            get => _addNewTeaCommand;
        }

        private bool CanAddNewTea()
        {
            /*if (EditedTea != null)
                return false;*/
            return true;
        }

        private RelayCommand _saveTeaCommand;

        public RelayCommand SaveTeaCommand
        {
            get => _saveTeaCommand;
        }

        private void SaveTea()
        {
            Teas.Add(EditedTea);
            _provider.saveProduct(EditedTea.Tea);
        }

        private bool CanSaveTea()
        {
            if ((EditedTea != null) &&
                !EditedTea.HasErrors &&
                !Teas.Contains(EditedTea))
            {
                return true;
            }

            return false;
        }

        private RelayCommand _deleteTeaCommand;

        public RelayCommand DeleteTeaCommand
        {
            get => _deleteTeaCommand;
        }

        private void DeleteTea()
        {
            _provider.DeleteProduct(EditedTea.Tea);
            Teas.Remove(EditedTea);
            
        }

        private bool CanDeleteTea()
        {
            if ((EditedTea != null) &&
                Teas.Contains(EditedTea))
            {
                return true;
            }

            return false;
        }

        public bool IsDirty
        {
            get; set;
        }
    }
}

