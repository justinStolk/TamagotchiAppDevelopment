using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TamagotchiV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureView : ContentView, INotifyPropertyChanged
    {
        public Creature MyCreature { get; set;}
        public string CreatureImage = "Gatomon.png";
        public CreatureView()
        {
            MyCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem().Result;
            if(MyCreature == null)
            {
                MyCreature = new Creature("Gatomon", 0.02f, 0.05f, 0.1f, 0.12f, 0.1f, 0.1f);
                DependencyService.Get<IDataStore<Creature>>().CreateItem(MyCreature);
            }

            BindingContext = this;
            InitializeComponent();
        }
    }
}