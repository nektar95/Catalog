using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModels
{
    public class TeaViewModel : ViewModelBase
    {
        private ITea _tea;
        public ITea Tea { get => _tea; }

        public TeaViewModel(ITea tea, List<IProducer> listProducers)
        {
            _tea = tea;
            _producers = new ObservableCollection<IProducer>(listProducers);
        }

        [Required(ErrorMessage = "Name has to be specified!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 100 characters long!")]
        public string Name
        {
            get => _tea.Name;
            set
            {
                _tea.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Year has to be specified!")]
        [Range(1900, 2018, ErrorMessage = "Year must be between 1900 and 2018")]
        public int ProductionYear
        {
            get => _tea.ProductionYear;
            set
            {
                _tea.ProductionYear = value;
                Validate();
                OnPropertyChanged("ProductionYear");
            }
        }

        [Required(ErrorMessage = "Temperature has to be specified!")]
        [Range(0, 100, ErrorMessage = "Temperature must be between 0 and 100")]
        public int Temperature
        {
            get => _tea.Temperature;
            set
            {
                _tea.Temperature = value;
                Validate();
                OnPropertyChanged("Temperature");
            }
        }

        [Required(ErrorMessage = "Producer has to be specified!")]
        public IProducer Producer
        {
            get => _tea.Producer;
            set
            {
                _tea.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }

        [Required(ErrorMessage = "Type has to be specified!")]
        public TeaType Type
        {
            get => _tea.Type;
            set
            {
                _tea.Type = value;
                Validate();
                OnPropertyChanged("Type");
            }
        }

        private ObservableCollection<IProducer> _producers;

        public ObservableCollection<IProducer> Producers
        {
            get => _producers;
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);
            
            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
