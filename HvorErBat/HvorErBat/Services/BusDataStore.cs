using HvorErBat.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Maps;

namespace HvorErBat.Services
{
    class BusDataStore : IBusDataStore<Bus>
    {

        BusApi busApi = new BusApi();

        public async Task<IEnumerable<Bus>> GetBusList()
        {
            List<Bus> busList = new List<Bus>();
            var jsonArray = await busApi.GetBusRespone();


            var firstObject = jsonArray[0] as JArray;
            for (int i = 0; i < firstObject.Count - 1; i++)
            {
                var item = firstObject[i];

                var title = item[0].ToString().Replace(" (Bornholm)", "").Replace(" (Born", "").Replace(" (B", "");
                var longitude = ((double)item[1] / 1000000);
                var latitude = ((double)item[2] / 1000000);
                var destination = item[7].ToString();
                List<Position> coordinatesList = new List<Position>();
                foreach (var o in item[8])
                {
                    coordinatesList.Add(new Position((double)o[0] / 1000000, (double)o[1] / 1000000));
                }
                var id = item[3].ToString();
                var nextStop = item[11].ToString().Replace(" (Bornholm)", "").Replace(" (Born", "").Replace(" (B", "");
                var icon = 1;
                var delayInMinutes = item[6].ToString();
                
                busList.Add(new Bus { Title = title, Longitude = longitude, 
                    Latitude = latitude, Destination = destination, 
                    CoordinatesList = coordinatesList, Id = id, NextStop = nextStop,
                    Icon = icon, DelayInMinutes = delayInMinutes});
            }
            return busList;
        }

    }
}
