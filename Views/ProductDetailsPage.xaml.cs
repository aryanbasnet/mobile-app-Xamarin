using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStoreApp.Models;
using BookStoreApp.Services;

namespace BookStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        private Product product;
        private int quantity = 1;

        public ProductDetailsPage(Product product)
        {
            InitializeComponent();
            this.product = product;
            BindingContext = product;
            QuantityLabel.Text = quantity.ToString();
        }

        private void OnIncreaseQuantity(object sender, EventArgs e)
        {
            quantity++;
            QuantityLabel.Text = quantity.ToString();
        }

        private void OnDecreaseQuantity(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                QuantityLabel.Text = quantity.ToString();
            }
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            CartService.Instance.AddToCart(product, quantity);
            await DisplayAlert("Cart", $"Added {quantity} x {product.Name} to cart.", "OK");
        }
    }
}