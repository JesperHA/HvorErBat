using HvorErBat.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HvorErBat.Services
{
    class BusDeserializer
    {

        static BusApi busApi = new BusApi();

        public static async Task<IEnumerable<Bus>> GetBusList()
        {
            List<Bus> busList = new List<Bus>();
            var jsonArray = await busApi.GetBusRespone();


            var firstObject = jsonArray[0] as JArray;

            for (int i = 0; i < firstObject.Count - 1; i++)
            {
                var item = firstObject[i];

                var title = item[0].ToString().Replace(" (Bornholm)", "").Replace(" (Born", "").Replace(" (B", "");
                var longitude = ((double)item[1]);
                var latitude = ((double)item[2]);
                var destination = item[7];
                var coordinateslist = item[8] as JArray;
                var id = item[3].ToString();



                Console.WriteLine("Bus nummer: " + item[0]);
            }





            return busList;
        }

    }
}
