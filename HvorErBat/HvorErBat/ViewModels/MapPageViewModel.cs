using System;
using System.Collections.Generic;
using System.Text;
using HvorErBat.Services;
using HvorErBat.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmHelpers;
using Xamarin.Forms.Maps;

namespace HvorErBat.ViewModels
{
    class MapPageViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Bus> BusList { get; }
        public Command LoadBusListCommand { get; }
        public Command PrintBusListCommand { get;  }
        public Map Map { get; private set; }

        BusDataStore busDataStore = new BusDataStore();


        public MapPageViewModel()
        {
            Map = new Map();
            BusList = new ObservableRangeCollection<Bus>();
            LoadBusListCommand = new Command(async () => await ExecuteLoadBusList());
            //PrintBusListCommand = new Command(async () => await PrintBusList());
        }

        //async Task PrintBusList()
        //{


        //    IsBusy = true;

        //    try
        //    {
        //        Console.WriteLine("This is the busList: " + BusList);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        

        public async Task ExecuteLoadBusList()
        {

            IsBusy = true;

            try
            {
                BusList.Clear();
                var items = await busDataStore.GetBusList();
                BusList.AddRange(items);

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
