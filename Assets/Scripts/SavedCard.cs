using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [Serializable]
    public class SavedCardsList
    {
        public List<SavedCard> Cards = new List<SavedCard>();
    }

    [Serializable]
    public class SavedCard
    {
        public string Title;
        public string Description;
        public string IconName;
        public string EffectName;

        public SavedCard() { }

        public SavedCard(string title, string desc, string iconName, string effectName)
        {
            Title = title;
            Description = desc;
            IconName = iconName;
            EffectName = effectName;
        }
    }
}
