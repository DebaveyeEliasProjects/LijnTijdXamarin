using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models.Doorkomsten;
using LijnTijd.Models.Halte;
using LijnTijd.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LijnTijd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLijnPage : ContentPage
    {
        public ViewLijnPage(DoorkomstProperties properties)
        {
            InitializeComponent();

            lblBestemming.Text = properties.Bestemming;
            lblNumber.Text = properties.Lijn.LijnnummerPubliek.ToString();
            numberColor.BackgroundColor = Color.FromHex(properties.Color);
            lblVertrektijd.Text = properties.TimeFormat;
            lblOmschrijving.Text = properties.Lijn.Omschrijving;
            loaderData.IsRunning = true;
            Start(properties);

        }


        public async Task Start(DoorkomstProperties properties)
        {

            HalteGroup halteGroup = await LineRpository.GetHaltes(properties);
            loaderData.IsRunning = false;

            foreach (Halte halte in halteGroup.Haltes)
            {
                Console.WriteLine(halte.HalteNummer + " - " + ShowCloseHaltes.ClickedHalte.Id);
                if (halte.HalteNummer == ShowCloseHaltes.ClickedHalte.Id)
                {
                    Console.WriteLine("Ja er zit eentje");
                    halte.isCurrent = true;
                    break;
                }
            }
            lstViewShowHaltes.ItemsSource = halteGroup.Haltes;

        }

        private void LstViewShowHaltes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;


            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}