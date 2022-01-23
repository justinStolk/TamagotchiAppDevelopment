using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TamagotchiV2
{
    public partial class App : Application
    {   
        public App()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new LocalCreatureStorage());

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new CreatureView()));
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
