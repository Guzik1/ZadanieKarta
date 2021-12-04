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

        void Start()
        {
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
            // TODO: implement card save to file in JSON format.
        }

        public void OnUseCard(CardController card)
        {
            if(card.UseEffect != null)
            {
                playerAplayEffect.ApplayEffect(card.UseEffect);

                GenerateRandomCard();
            }
        }
    }
}
