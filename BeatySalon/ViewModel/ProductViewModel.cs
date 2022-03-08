using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using BeatySalon.Model;

namespace BeatySalon.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        private Manufacturer _selectedManufacturer = new Manufacturer();

        private ICollectionView _filterCollectionView;

        private string _filter;

        public List<Product> BasketList { get; set; } = new List<Product>();
        public ObservableCollection<Manufacturer> ManufacturersComboBox { get; set; } = new ObservableCollection<Manufacturer>();
        public ObservableCollection<Product> GetProducts { get; set; } = new ObservableCollection<Product>();

        private int _counterSum = 0;

        public int CounterSum
        {
            get { return _counterSum = GetProducts.Count();  }
        }

        private int _counter = 0;

        public int Counter
        {
            get { 
                return  _counter; }
            set { 
                _counter = value;
                OnPropertyChanged("Counter"); 
            }
        }

        private Product _selectedItem = new Product();

        public Product SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value != null)
                    _filter = value;
                _filterCollectionView.Refresh();
                OnPropertyChanged("Filter");

                Counter = 0;
                foreach (var item in _filterCollectionView)
                {
                    Counter++;
                }
            }
        }

        private string _manufacturerName = string.Empty;

        public string ManufacturerName
        {
            get => _manufacturerName;

            set
            {
                _manufacturerName = value;
                _filterCollectionView?.Refresh();
                OnPropertyChanged("ManufacturerName");
            }
        }

        public Manufacturer SelectedManufacturer
        {
            get { return _selectedManufacturer; }
            set
            {
                if (value != null)
                    _selectedManufacturer = value;
                _filter = SelectedManufacturer.ID.ToString();
                _filterCollectionView.Refresh();
                OnPropertyChanged("SelectedManufacturer");

                Counter = 0;
                foreach (var item in _filterCollectionView)
                {
                    Counter++;
                }
            }
        }

        public ProductViewModel()
        {
            using (BeatySalonEntities db = new BeatySalonEntities())
            {
                ManufacturersComboBox.Add(new Manufacturer() { ID = 0, Name = "Выбрать все элементы" });

                foreach (var item in db.Product)
                {
                    GetProducts.Add(item);
                }

                foreach (var item in db.Manufacturer)
                {
                    ManufacturersComboBox.Add(item);
                }

                db.Dispose();
            }
            _filterCollectionView = CollectionViewSource.GetDefaultView(GetProducts);
            _filterCollectionView.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            Product product = obj as Product;

            if (string.IsNullOrWhiteSpace(Filter))
            {
                return true;
                
            }
            if (product.Title.Contains(Filter))
            {
                return true;
            }
            if (product.Cost.ToString().Contains(Filter))
            {
                return true;
            }
            if (product.ManufacturerID.ToString().Contains(Filter))
            {
                return true;
            }
            return false;
        }
    }
}
