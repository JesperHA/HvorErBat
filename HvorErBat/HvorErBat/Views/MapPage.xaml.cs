using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


            await UpdateMarkers();

        }


        protected async void reloadBusList()
        {
            await _viewModel.ExecuteLoadBusList();
            await UpdateMarkers();

        }

        List<Pin> pinList = new List<Pin>();
        List<Pin> toBeDeletedPins = new List<Pin>();


        protected async Task UpdateMarkers()
        {
            //add the to be removed pins to another list, since the looped list can't be altered while being looped
            foreach (var pin in pinList)
            {
                if(!_viewModel.BusList.Any(b => b.Id == pin.StyleId)){
                    toBeDeletedPins.Add(pin);
                }
            }
            //removing the to be deleted pins from the pinList, and clearing the pin off the map.
            foreach (var delete in toBeDeletedPins)
            {
                pinList.Remove(delete);
                map.Pins.Remove(delete);
            }
            toBeDeletedPins.Clear();

            // adds pins to the pinList if it does not already exist
            foreach (var bus in _viewModel.BusList)
            {

                if (!pinList.Exists(x => x.StyleId == bus.Id))
                {
                    Pin newPin = new Pin { StyleId = bus.Id, Label = bus.Title};
                    pinList.Add(newPin);
                    map.Pins.Add(newPin);
                }
            }


            for (int i = 0; i < _viewModel.BusList[0].CoordinatesList.Count; i++)
            {

                foreach (var bus in _viewModel.BusList)
                {

                    Pin pin = pinList.Find( x => x.StyleId == bus.Id);

                    var position = bus.CoordinatesList[i];

                    pin.Label = bus.Title;
                    pin.Position = position;

                    

                    //map.Pins.Add(new Pin
                    //{
                    //    Label = bus.Title,
                    //    Position = position
                    //});

                }
                await Task.Delay(1000);

            }

            reloadBusList();
        }
    }
}