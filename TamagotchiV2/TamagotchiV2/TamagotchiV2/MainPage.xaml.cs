using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace TamagotchiV2
{
    public partial class MainPage : ContentPage
    {
        public Creature creature;
        public MainPage(CreatureView view)
        {
            BindingContext = this;
            InitializeComponent();

            myView = view;
            creature = myView.MyCreature;

            var timer = new Timer { Interval = 1000, AutoReset = true };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            creature.Hunger += creature.FullnessModifier;
            if (creature.Hunger > 1) creature.Hunger = 1;
            creature.Thirst += creature.HydrationModifier;
            if (creature.Thirst > 1) creature.Thirst = 1;
            creature.Boredom += creature.BoredomModifier;
            if (creature.Boredom > 1) creature.Boredom = 1;
            creature.Loneliness += creature.SocialModifier;
            if (creature.Loneliness > 1) creature.Loneliness = 1;
            creature.Stimulation += creature.AttentionModifier;
            if (creature.Stimulation > 1) creature.Stimulation = 1;
            creature.Tired += creature.TiredModifier;
            if (creature.Tired > 1) creature.Tired = 1;

            var creatureStorage = DependencyService.Get<IDataStore<Creature>>();
            creatureStorage.UpdateItem(myView.MyCreature);

        }

        private void OnFoodButtonClicked(object sender, EventArgs e)
        {
            /*
            creature.Hunger -= creature.FullnessModifier;
            if (creature.Hunger < 0) creature.Hunger = 0;
            creature.Thirst -= creature.HydrationModifier;
            if (creature.Thirst < 0) creature.Thirst = 0;
            creature.Boredom -= creature.BoredomModifier;
            if (creature.Boredom < 0) creature.Boredom = 0;
            creature.Loneliness -= creature.SocialModifier;
            if (creature.Loneliness < 0) creature.Loneliness = 0;
            creature.Stimulation -= creature.AttentionModifier;
            if (creature.Stimulation < 0) creature.Stimulation = 0;
            creature.Tired -= creature.TiredModifier;
            if (creature.Tired < 0) creature.Tired = 0;
            */
            Navigation.PushAsync(new FoodPage(myView));

        }
    }
}
