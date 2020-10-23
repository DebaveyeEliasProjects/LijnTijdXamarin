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
    public partial class ViewStoppendeLijnen : ContentPage
    {
        public ViewStoppendeLijnen(Halte halte)
        {
            InitializeComponent();

            ToolbarItem item = new ToolbarItem
            {
                Text = "BusInfo",
                IconImageSource = ImageSource.FromResource("Assets.businfo.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item);

            lstViewShowHaltes.IsVisible = false;
            loaderData2.IsRunning = true;
            Start(halte);

        }

        public async Task Start(Halte halte)
        {

            DoorkomstGroup doorkomsts = await LineRpository.GetDoorKomsten(halte);
            
            loaderData2.IsRunning = false;
            lstViewShowHaltes.IsVisible = true;
            loaderData2.IsVisible = false;

            List<DoorkomstProperties> doorkomstPropertieses = new List<DoorkomstProperties>();
            foreach (Doorkomst doorkomst in doorkomsts.Doorkomsten)
            {
                foreach (DoorkomstProperties doorkomstPropertiese in doorkomst.Doorkomsts)
                {
                 doorkomstPropertieses.Add(doorkomstPropertiese);   
                }
            }
            doorkomstPropertieses.Sort();

            lstViewShowHaltes.ItemsSource = doorkomstPropertieses;

        }

        private void LstViewShowHaltes_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}