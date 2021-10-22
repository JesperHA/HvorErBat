using HvorErBat.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HvorErBat.Services
{
    class BusApi
    {
        static string BaseUrl = "https://www.rejseplanen.dk/bin/query.exe/mny?look_minx=14274082&look_maxx=15580768&look_miny=54950366&look_maxy=55352136&tpl=trains2json3&look_productclass=992&look_json=yes&performLocating=1&look_nv=get_ageofreport%7Cyes%7Cget_rtmsgstatus%7Cyes%7Cget_rtfreitextmn%7Cyes%7Czugposmode%7C2%7Cinterval%7C5000%7Cintervalstep%7C1000%7Cget_nstop%7Cyes%7Cget_pstop%7Cyes%7Cget_stopevaids%7Cyes%7Ctplmode%7Ctrains2json3%7C&interval=5000&intervalstep=1000&";

        internal async Task<JArray> GetBusRespone()
        {
            return await GetBusResponseAsync();
        }

        static HttpClient client;

        static BusApi()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };

        }

        public async Task<JArray> GetBusResponseAsync()
        {
            var response = await client.GetStringAsync("");
            var parsedJson = response.Replace("\")]", "\"]");
            var busJson = JsonConvert.DeserializeObject<JArray>(parsedJson);
            return busJson;
        }


            
    }

}
