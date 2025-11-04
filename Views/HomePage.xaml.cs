using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStoreApp.Models;
using BookStoreApp.Services;

namespace BookStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            CartService.Instance.PropertyChanged += CartService_PropertyChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateCartToolbarText();
        }

        private void CartService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CartService.TotalItems) || e.PropertyName == nameof(CartService.Items))
            {
                Device.BeginInvokeOnMainThread(UpdateCartToolbarText);
            }
        }

        private void UpdateCartToolbarText()
        {
            try
            {
                CartToolbarItem.Text = $"Cart ({CartService.Instance.TotalItems})";
            }
            catch
            {
                // ignore if toolbar not available yet
            }
        }

        private async void OnViewClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var product = btn?.CommandParameter as Product;
            if (product != null)
            {
                await Navigation.PushAsync(new ProductDetailsPage(product));
            }
        }

        private async void OnCartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}