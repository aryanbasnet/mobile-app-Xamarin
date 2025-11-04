using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStoreApp.Models;
using BookStoreApp.Services;

namespace BookStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            BindingContext = CartService.Instance;
        }

        private void OnDecreaseClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn?.CommandParameter as CartItem;
            if (item == null) return;

            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
            }
            else
            {
                CartService.Instance.RemoveFromCart(item);
            }
        }

        private void OnIncreaseClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn?.CommandParameter as CartItem;
            if (item == null) return;
            item.Quantity += 1;
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var item = btn?.CommandParameter as CartItem;
            if (item == null) return;
            CartService.Instance.RemoveFromCart(item);
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            if (CartService.Instance.Items.Count == 0)
            {
                await DisplayAlert("Cart", "Your cart is empty.", "OK");
                return;
            }

            // For prototype: clear cart and show success
            CartService.Instance.Clear();
            await DisplayAlert("Order", "Checkout complete. Thank you!", "OK");
            await Navigation.PopAsync();
        }
    }
}