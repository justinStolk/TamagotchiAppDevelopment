using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TamagotchiV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        public FoodPage(CreatureView view)
        {
            creatureView = view;
            BindingContext = this;
            InitializeComponent();
        }

        private void FeedMango(object sender, EventArgs e)
        {
            creatureView.MyCreature.Hunger -= 0.15f;
            DependencyService.Get<IDataStore<Creature>>().UpdateItem(creatureView.MyCreature);
        }

        private void FeedFries(object sender, EventArgs e)
        {
            creatureView.MyCreature.Hunger -= 0.25f;
            creatureView.MyCreature.Thirst += 0.1f;
            DependencyService.Get<IDataStore<Creature>>().UpdateItem(creatureView.MyCreature);
        }

        private void FeedRice(object sender, EventArgs e)
        {
            creatureView.MyCreature.Hunger -= 0.4f;
            creatureView.MyCreature.Boredom += 0.15f;
            DependencyService.Get<IDataStore<Creature>>().UpdateItem(creatureView.MyCreature);
        }
        private void OnMainPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(creatureView));
        }
    }
}