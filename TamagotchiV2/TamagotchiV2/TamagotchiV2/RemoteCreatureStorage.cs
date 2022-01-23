using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiV2
{
    public class RemoteCreatureStorage : IDataStore<Creature>
    {
        public async Task<bool> CreateItem(Creature item)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.PostAsync("https://tamagotchi.hku.nl/api/creatures", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Creature> ReadItem()
        {
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync("https://tamagotchi.hku.nl/api/creatures/1");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var creature = JsonConvert.DeserializeObject<Creature>(responseString);

                return creature;
            }
            else
            {
                if(response.StatusCode == HttpStatusCode.NotFound)
                {

                }
                    return null;
            }
        }

        public async Task<bool> UpdateItem(Creature item)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.PutAsync("https://tamagotchi.hku.nl/api/creatures/1", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    
                }
                return false;
            }
        }
        public async Task<bool> DeleteItem(Creature item)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.DeleteAsync("https://tamagotchi.hku.nl/api/creatures/1");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {

                }
                return false;
            }
        }
    }
}
