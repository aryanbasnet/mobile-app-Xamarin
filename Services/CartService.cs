using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BookStoreApp.Models;

namespace BookStoreApp.Services
{
    public class CartService : INotifyPropertyChanged
    {
        private static readonly CartService instance = new CartService();
        public static CartService Instance => instance;

        public ObservableCollection<CartItem> Items { get; } = new ObservableCollection<CartItem>();

        private CartService()
        {
            Items.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(TotalItems));
                OnPropertyChanged(nameof(TotalPrice));
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int TotalItems => Items.Sum(i => i.Quantity);

        public double TotalPrice => Math.Round(Items.Sum(i => i.TotalPrice), 2);

        public void AddToCart(Product product, int quantity = 1)
        {
            if (product == null || quantity <= 0) return;

            var existing = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                var item = new CartItem { Product = product, Quantity = quantity };
                item.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(CartItem.Quantity) || e.PropertyName == nameof(CartItem.TotalPrice))
                    {
                        OnPropertyChanged(nameof(TotalItems));
                        OnPropertyChanged(nameof(TotalPrice));
                    }
                };

                Items.Add(item);
            }

            OnPropertyChanged(nameof(TotalItems));
            OnPropertyChanged(nameof(TotalPrice));
        }

        public void RemoveFromCart(CartItem item)
        {
            if (item == null) return;
            if (Items.Contains(item))
            {
                Items.Remove(item);
                OnPropertyChanged(nameof(TotalItems));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public void Clear()
        {
            Items.Clear();
            OnPropertyChanged(nameof(TotalItems));
            OnPropertyChanged(nameof(TotalPrice));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
