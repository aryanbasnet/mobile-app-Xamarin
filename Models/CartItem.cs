using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookStoreApp.Models
{
    public class CartItem : INotifyPropertyChanged
    {
        public Product Product { get; set; }

        private int quantity = 1;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity == value) return;
                quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => Product != null ? Product.Price * Quantity : 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
