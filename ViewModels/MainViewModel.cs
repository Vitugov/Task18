using EntityToWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Task18.Model;
using Task18.Repository;
using Task18.View;

namespace Task18.ViewModels
{
    public class MainViewModel : INotifyPropertyChangedPlus
    {
        private ObservableCollection<IAnimal> _itemCollection;
        public ObservableCollection<IAnimal> ItemCollection
        {
            get => _itemCollection;
            set => Set(ref _itemCollection, value);
        }

        private ListCollectionView _itemCollectionView;

        public ListCollectionView ItemCollectionView
        {
            get => _itemCollectionView;
            set => Set(ref _itemCollectionView, value);
        }


        private IAnimal? _selectedItem;
        public IAnimal? SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        private IRepository _repository;

        public ICommand AddNewItemCommand { get; }
        public ICommand ChangeItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        public MainViewModel(IRepository repository) : this()
        {
            _repository = repository;
            ItemCollection = [.. _repository.GetAll()];
            ItemCollectionView = new ListCollectionView(ItemCollection);
        }

        public MainViewModel()
        {
            AddNewItemCommand = new RelayCommand(obj => ExecuteAddNewItem());
            ChangeItemCommand = new RelayCommand(obj => ExecuteChangeItem(SelectedItem), obj => SelectedItem != null);
            DeleteItemCommand = new RelayCommand(obj => ExecuteDeleteItem(SelectedItem), obj => SelectedItem != null);
        }

        private void ExecuteChangeItem(IAnimal item = null)
        {
            var itemVM = new ItemViewModel(item, false, ItemCollection, _repository);
            var itemView = new ItemWindow(itemVM);
            itemView.ShowDialog();
        }

        private void ExecuteAddNewItem()
        {
            var preNewItemVM = new PreNewItemViewModel(ItemCollection, _repository);
            var preNewItemView = new PreNewItemWindow(preNewItemVM);
            preNewItemView.ShowDialog();
        }

        private void ExecuteDeleteItem(IAnimal item)
        {
            _repository.Delete(item.Id);
            ItemCollection.Remove(item);
        }
    }
}
