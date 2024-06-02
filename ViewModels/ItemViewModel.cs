using EntityToWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Task18.Model;
using Task18.Repository;
using Microsoft.VisualBasic;

namespace Task18.ViewModels
{
    internal class ItemViewModel : INotifyPropertyChangedPlus
    {

        private IAnimal _editableItem;
        public IAnimal EditableItem
        {
            get => _editableItem;
            set => Set(ref _editableItem, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly ObservableCollection<IAnimal> _collection;
        private readonly IAnimal _original;
        private readonly bool _isNew = false;
        private readonly IRepository _repository;

        public ItemViewModel(IAnimal item, bool isNew, ObservableCollection<IAnimal> itemCollection, IRepository repository)
        {
            _isNew = isNew;
            _original = item;

            EditableItem = (IAnimal)_original.Clone();
            _collection = itemCollection;
            _repository = repository;
            SaveCommand = new RelayCommand(obj => ExecuteSaveCommand(obj));
            CancelCommand = new RelayCommand(obj => CloseWindow(obj));
        }

        private void ExecuteSaveCommand(object obj)
        {
            if (_isNew)
            { 
                _repository.Add(EditableItem);
            }
            else
            {
                _repository.Update(EditableItem);
                _collection.Remove(_original);
            }
            _collection.Add(EditableItem);
            CloseWindow(obj);
        }

        internal void CloseWindow(object obj) => (obj as Window).Close();
    }
}
