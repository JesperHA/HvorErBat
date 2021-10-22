using System;
using System.Collections.Generic;
using System.Text;
using HvorErBat.Services;
using HvorErBat.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HvorErBat.ViewModels
{
    class MapPageViewModel : BaseViewModel
    {

        public ObservableCollection<Bus> BusList { get; }
        public Command LoadBusListCommand { get; }


        public MapPageViewModel()
        {
            BusList = new ObservableCollection<Bus>();
            LoadBusListCommand = new Command(async () => await ExecuteLoadBusList());
        }

        async Task ExecuteLoadBusList()
        {
            IsBusy = true;

            try
            {
                BusList.Clear();
                var items = await BusDeserializer.GetBusList();
                foreach (var item in items)
                {
                    BusList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void onAppearing()
        {
        }





    }
}
