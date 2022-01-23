using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TamagotchiV2
{
    public class LocalCreatureStorage : IDataStore<Creature>
    {
        public async Task<bool> CreateItem(Creature item)
        {
            string creatureToString = JsonConvert.SerializeObject(item);
            Preferences.Set("MyCreature", creatureToString);
            return true;
        }

        public Task<Creature> ReadItem()
        {
            string creatureAsJson = Preferences.Get("MyCreature", "");
            Creature myCreature = JsonConvert.DeserializeObject<Creature>(creatureAsJson);
            return Task.FromResult(myCreature);
        }

        public async Task<bool> UpdateItem(Creature item)
        {
            string savedCreatureAsText = Preferences.Get("MyCreature", "");
            Creature savedCreature = JsonConvert.DeserializeObject<Creature>(savedCreatureAsText);
            if(savedCreature != null)
            {
                string creatureToString = JsonConvert.SerializeObject(item);
                Preferences.Set("MyCreature", creatureToString);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteItem(Creature item)
        {
            string savedCreatureAsText = Preferences.Get("MyCreature", "");
            Creature savedCreature = JsonConvert.DeserializeObject<Creature>(savedCreatureAsText);
            if (savedCreature != null)
            {
                Preferences.Set("MyCreature", null);
                return true;
            }
            return false;
        }

    }
}
