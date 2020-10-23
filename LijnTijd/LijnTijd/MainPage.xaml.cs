using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models.Halte;
using LijnTijd.Repositories;
using LijnTijd.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LijnTijd
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void RadiusSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblRadiusChanger.Text = e.NewValue + " meter";
        }

        private async void Button_OnPressed(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new ShowCloseHaltes( radiusSlider.Value));

            
            

        }
    }
}
