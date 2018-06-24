using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BLC;
using GUI;

namespace GUI.ViewModels
{
    public class ProducersListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers { get; set; } = new ObservableCollection<ProducerViewModel>();
        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private DataProvider _provider;

        public string FilterValue { get; set; }

        public ProducersListViewModel()
        {
            _provider = MainWindow._provider;
            OnPropertyChanged("Producers");
            GetAllProducers();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Producers);
            _filterDataCommand = new RelayCommand(param => this.FilterData());

            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer(), param => this.CanAddNewProducer());

            _saveProducerCommand = new RelayCommand(param => this.SaveProducer(), param => this.CanSaveProducer());

            _deleteProducerCommand = new RelayCommand(param => this.DeleteProducer(), param => this.CanDeleteProducer());
        }

        private void GetAllProducers()
        {
            foreach (var producer in _provider.getProducers)
            {
                Producers.Add(new ProducerViewModel(producer));
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

        private ProducerViewModel _editedProducer;
        public ProducerViewModel EditedProducer
        {
            get => _editedProducer;
            set
            {
                _editedProducer = value;
                OnPropertyChanged(nameof(EditedProducer));
            }
        }

        private void AddNewProducer()
        {
            EditedProducer = new ProducerViewModel(_provider.addNewProducer());
            EditedProducer.Name = "";
            EditedProducer.Validate();
        }

        private RelayCommand _addNewProducerCommand;

        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }

        private bool CanAddNewProducer()
        {
            return true;
        }

        private RelayCommand _saveProducerCommand;

        public RelayCommand SaveProducerCommand
        {
            get => _saveProducerCommand;
        }

        private void SaveProducer()
        {
            Producers.Add(EditedProducer);
            _provider.SaveProducer(EditedProducer.Producer);
        }

        private bool CanSaveProducer()
        {
            if ((EditedProducer != null) &&
                !EditedProducer.HasErrors &&
                !Producers.Contains(EditedProducer))
            {
                return true;
            }

            return false;
        }

        private RelayCommand _deleteProducerCommand;

        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }

        private void DeleteProducer()
        {
            _provider.DeleteProducer(EditedProducer.Producer);
            Producers.Remove(EditedProducer);

        }

        private bool CanDeleteProducer()
        {
            if ((EditedProducer != null) &&
                Producers.Contains(EditedProducer))
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

