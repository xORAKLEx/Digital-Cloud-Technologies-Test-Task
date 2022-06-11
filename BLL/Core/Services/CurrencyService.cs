using BLL.Core.Models;
using BLL.Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<IEnumerable<Asset>> GetAssets()
        {

            var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://www.cryptingup.com/api/markets");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<AssetList>(responseBody);

                return res.Assets;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
            return null;
        }

        public async Task<IEnumerable<Market>> GetMarkets()
        {

            var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://www.cryptingup.com/api/markets");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var res = JsonConvert.DeserializeObject<MarketList>(responseBody);

                return res.Markets;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
            return null;
        }


    }

}
