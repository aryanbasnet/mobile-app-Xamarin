using BookStoreApp.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStoreApp
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                // Log and show a fallback page so the emulator doesn't show a black screen
                Debug.WriteLine("InitializeComponent failed: " + ex);
                MainPage = new ContentPage
                {
                    BackgroundColor = Color.White,
                    Content = new StackLayout
                    {
                        Padding = new Thickness(24),
                        Children =
                        {
                            new Label { Text = "App initialization error", FontAttributes = FontAttributes.Bold, TextColor = Color.Black, FontSize = 20 },
                            new Label { Text = ex.Message, TextColor = Color.Black }
                        }
                    }
                };
                return;
            }

            Color primary = Color.FromHex("#4CAF50");
            try
            {
                if (Resources != null && Resources.ContainsKey("PrimaryColor"))
                {
                    primary = (Color)Resources["PrimaryColor"];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to read PrimaryColor resource: " + ex);
            }

            MainPage = new NavigationPage(new HomePage())
            {
                BarBackgroundColor = primary,
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}


