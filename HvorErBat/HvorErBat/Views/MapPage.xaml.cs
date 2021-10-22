using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HvorErBat.Models;
using HvorErBat.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace HvorErBat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        MapPageViewModel  _viewModel;
        public MapPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MapPageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.ExecuteLoadBusList();


            // Works, but Latitude and Longitude is reversed.
            map.Pins.Add(new Pin
            {
                Label = "Bus 1",
                Position = _viewModel.BusList[0].CoordinatesList[0]
            });
        }
    }
}