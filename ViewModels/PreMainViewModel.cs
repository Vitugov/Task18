using EntityToWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task18.SaveModels;
using Task18.Repository;
using System.Windows;
using Task18.View;

namespace Task18.ViewModels
{
    public class PreMainViewModel :INotifyPropertyChangedPlus
    {
        public List<KeyValuePair<string, ISaver>> SaveClassDictionary { get; set; }
        private ISaver? selectedSaver;
        public ISaver? SelectedSaver
        {
            get => selectedSaver;
            set => Set(ref selectedSaver, value);
        }
        private bool needInitialization;
        public bool NeedInitialization
        {
            get => needInitialization;
            set => Set(ref needInitialization, value);
        }

        public ICommand ContinueCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public PreMainViewModel()
        {
            SaveClassDictionary = new SaveFactory().GetSaversDic();
            ContinueCommand = new RelayCommand(ExecuteContinueCommand, obj => SelectedSaver != null);
            CancelCommand = new RelayCommand(CloseWindow);
        }

        private void ExecuteContinueCommand(object obj)
        {
            var repository = new Repository.Repository(SelectedSaver);
            if (NeedInitialization)
            {
                new Initialization().Init(repository);
            }
            var vm = new MainViewModel(repository);
            new MainWindow(vm).Show();
            CloseWindow(obj);
        }

        private void CloseWindow(object obj) => (obj as Window).Close();
    }
}
