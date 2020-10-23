using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models.Halte;
using LijnTijd.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LijnTijd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowCloseHaltes : ContentPage
    {
        public ShowCloseHaltes(double Radius)
        {
            InitializeComponent();
            lstViewShowHaltes.IsVisible = false;
            loaderData.IsRunning = true;
            
            Start(Radius);

            

        }

        public async Task<Location> GetLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }
        public async void  Start( double Radius)
        {
            

            try
            {
                Location loc = await GetLocation();

                HalteGroup halteGroup =
                    await LineRpository.getHaltesNearby(loc.Latitude, loc.Longitude, Radius);
                loaderData.IsRunning = false;
                lstViewShowHaltes.IsVisible = true;
                loaderData.IsVisible = false;
                lstViewShowHaltes.ItemsSource = halteGroup.Haltes;

            }
            catch (PermissionException exception)
            {
                await DisplayAlert("No permission", "Gelieve uw locatievoorzieningen aan te zetten voor LijnTijd",
                    "Sluit");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Nothing found", "Er zijn geen haltes gevonden binnen uw geselecteerde radius",
                    "Probeer opnieuw");
                await Navigation.PopAsync();

            }

        }

        private void LstViewShowHaltes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item ==null) return;

            //Do stuff
            Halte halte = (Halte)e.Item;
            Navigation.PushAsync(new ViewStoppendeLijnen(halte));

            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}