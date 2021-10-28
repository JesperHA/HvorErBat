using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HvorErBat.Models;
using HvorErBat.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Xaml;
using System.IO;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using Image = System.Drawing.Image;

namespace HvorErBat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        MapPageViewModel  _viewModel;
        Position startPos = new Position(55.1303431, 14.9221519);
        Distance startDistance = new Distance(20000);
        public MapPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MapPageViewModel();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(startPos, startDistance));
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


        //public static System.Drawing.Bitmap ToBitmap<TPixel>(this Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
        //        image.Save(memoryStream, imageEncoder);

        //        memoryStream.Seek(0, SeekOrigin.Begin);

        //        return new System.Drawing.Bitmap(memoryStream);
        //    }
        //}





        protected async Task UpdateMarkers()
        {
            //add the to be removed pins to another list, since the looped list can't be altered while being looped
            foreach (var pin in pinList)
            {
                if(!_viewModel.BusList.Any(b => b.Id == pin.Tag.ToString())){
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

                if (!pinList.Exists(x => x.Tag.ToString() == bus.Id))
                {
                    Pin newPin = new Pin {  Tag = bus.Id, Label = bus.Title};
                    pinList.Add(newPin);
                    map.Pins.Add(newPin);
                }
            }


            for (int i = 0; i < _viewModel.BusList[0].CoordinatesList.Count; i++)
            {

                foreach (var bus in _viewModel.BusList)
                {

                    Pin pin = pinList.Find( x => x.Tag.ToString() == bus.Id);

                    var position = bus.CoordinatesList[i];

                    pin.Label = bus.Title;
                    pin.Position = position;
                    pin.Icon = BitmapDescriptorFactory.FromBundle("outerCircle");
                    pin.Anchor = new Xamarin.Forms.Point(0.5, 0.5);
                    
                    


                }
                await Task.Delay(1000);

            }

            reloadBusList();
        }
    }
}