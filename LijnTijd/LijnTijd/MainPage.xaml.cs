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

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                HalteGroup halteGroup =
                    await LineRpository.getHaltesNearby(location.Latitude, location.Longitude, radiusSlider.Value);
                await Navigation.PushAsync(new ShowCloseHaltes(halteGroup));

            }
            catch (PermissionException exception)
            {
                await DisplayAlert("No permission", "Gelieve uw locatievoorzieningen aan te zetten voor LijnTijd",
                    "Sluit");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Nothing found", "Er zijn geen haltes gevonden binnen uw geselecteerde radius",
                    "Probeer opnieuw");

            }
            

        }
    }
}
