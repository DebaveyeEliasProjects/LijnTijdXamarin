using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models.Halte;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LijnTijd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowCloseHaltes : ContentPage
    {
        public ShowCloseHaltes(HalteGroup halteGroup)
        {
            InitializeComponent();

            lstViewShowHaltes.ItemsSource = halteGroup.Haltes;

        }
    }
}