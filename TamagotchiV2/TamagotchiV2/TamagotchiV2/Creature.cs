using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TamagotchiV2
{
    public class Creature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Creature(string name, float fuMod, float hyMod, float enMod, float soMod, float atMod, float meMod)
        {
            Name = name;
            Hunger = 0.5f;
            Thirst = 0.5f;
            Boredom = 0.5f;
            Loneliness = 0.5f;
            Stimulation = 0.5f;
            Tired = 0.5f;

            FullnessModifier = fuMod;
            HydrationModifier = hyMod;
            BoredomModifier = enMod;
            SocialModifier = soMod;
            AttentionModifier = atMod;
            TiredModifier = meMod;
        }
        public string Name { get; set; }
        public float Hunger { get; set; }
        public float Thirst { get; set; }
        public float Boredom { get; set; }
        public float Loneliness { get; set; }
        public float Stimulation { get; set; }
        public float Tired { get; set; }

        public float FullnessModifier;
        public float HydrationModifier;
        public float BoredomModifier;
        public float SocialModifier;
        public float AttentionModifier;
        public float TiredModifier;

    }
}
