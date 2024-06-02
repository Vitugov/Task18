using EntityToWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task18.Model;
using Task18.Repository;
using Task18.SaveModels;
using Task18.View;

namespace Task18.ViewModels
{
    public class PreNewItemViewModel : INotifyPropertyChangedPlus
    {
        public List<KeyValuePair<string, string>> ComboDic { get; set; } = [];
        private IRepository _repository;
        private ObservableCollection<IAnimal> _itemCollection;
        private string personalType = "Add new animal type";
        private string? selectedType;
        public string? SelectedType
        {
            get => selectedType;
            set
            {
                Set(ref selectedType, value);
                IsNewAnimalTypeVisible = selectedType == personalType ? true : false;
            }
        }

        private bool isNewAnimalTypeVisible = false;
        public bool IsNewAnimalTypeVisible
        {
            get => isNewAnimalTypeVisible;
            set => Set(ref isNewAnimalTypeVisible, value);
        }
        private string newAnimalType = "";
        public string NewAnimalType
        {
            get => newAnimalType;
            set => Set(ref newAnimalType, value);
        }

        public ICommand ContinueCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public PreNewItemViewModel(ObservableCollection<IAnimal> itemCollection, IRepository repository)
        {
            _itemCollection = itemCollection;
            _repository = repository;
            var dic = new AnimalFactory()
                .GetTypes()
                .Select(type => new KeyValuePair<string,string>(type, type))
                .ToList();
            dic.Add(new KeyValuePair<string, string>(personalType, personalType));
            ComboDic = dic;
            ContinueCommand = new RelayCommand(ExecuteContinueCommand, obj => SelectedType != null);
            CancelCommand = new RelayCommand(CloseWindow);
        }

        private void ExecuteContinueCommand(object obj)
        {
            var preferedType = IsNewAnimalTypeVisible ? NewAnimalType : SelectedType;
            var newAnimal = new AnimalFactory().CreateAnimal(preferedType);
            var itemViewModel = new ItemViewModel(newAnimal, true, _itemCollection, _repository);
            var itemView = new ItemWindow(itemViewModel);
            itemView.Show();
            CloseWindow(obj);
        }

        private void CloseWindow(object obj) => (obj as Window).Close();

    }
}
