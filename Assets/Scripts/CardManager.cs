using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CardManager: MonoBehaviour
    {
        [Header("Cards Parts Definition")]
        public List<string> Titles;
        public List<string> Descriptions;
        public List<Sprite> Icons;
        public List<CardEffect> Effects;

        [Header("Card Object")]
        public GameObject CardPrefab;
        public Transform CardParent;
        public bool RandomCardOnStart = false;

        CardController CachedCard;
        AplayableEffect playerAplayEffect;

        JSONFileManager fileManager;

        void Start()
        {
            fileManager = new JSONFileManager(Application.dataPath + "\\cards.txt");

            playerAplayEffect = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            GameObject cardObject = Instantiate(CardPrefab, CardParent);
            CachedCard = cardObject.GetComponent<SimplyCardController>();
            CachedCard.OnCardUseAction = OnUseCard;

            if(RandomCardOnStart)
                GenerateRandomCard();
        }

        public void GenerateRandomCard()
        {
            string title = Titles.Count > 0 ? Titles[Random.Range(0, Titles.Count)] : "";
            string desc = Descriptions.Count > 0 ?  Descriptions[Random.Range(0, Descriptions.Count)] : "";
            Sprite icon = Icons.Count > 0 ? Icons[Random.Range(0, Icons.Count)] : null;
            CardEffect effect = Effects.Count > 0 ? Effects[Random.Range(0, Effects.Count)] : null;

            CachedCard.SetNewData(title, desc, icon, effect);
        }

        public void SaveCard()
        {
            if (!CachedCard.Inicialized || CachedCard.Saved)
                return;

            CachedCard.Saved = true;

            SavedCardsList scl = fileManager.LoadFromFile<SavedCardsList>();

            if (scl == null)
                scl = new SavedCardsList();

            SavedCard sc = new SavedCard(CachedCard.Title, CachedCard.Desc, CachedCard.Icon.name, CachedCard.UseEffect);
            scl.Cards.Add(sc);

            fileManager.SaveToFile(scl);           
        }

        public void OnUseCard(CardController card)
        {
            if(CachedCard.Inicialized)
            {
                playerAplayEffect.ApplayEffect(card.UseEffect);

                GenerateRandomCard();
            }
        }
    }
}
