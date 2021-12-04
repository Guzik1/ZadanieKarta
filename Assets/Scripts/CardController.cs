using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class CardController: MonoBehaviour
    {
        public TextMeshProUGUI TitleText;
        public TextMeshProUGUI DescriptionText;
        public Image IconImage;
        [HideInInspector] public CardEffect UseEffect;
        [HideInInspector] public Action<CardController> OnCardUseAction;

        [HideInInspector] public bool Inicialized = false;
        [HideInInspector] public bool Saved = false;

        [HideInInspector] public string Title;
        [HideInInspector] public string Desc;
        [HideInInspector] public Sprite Icon;

        public virtual void SetNewData(string title, string decription, Sprite icon, CardEffect useEffect)
        {
            Inicialized = true;
            Saved = false;

            TitleText.text = title;
            DescriptionText.text = decription;
            IconImage.sprite = icon;
            UseEffect = useEffect;

            Title = title;
            Desc = decription;
            Icon = icon;
        }

        public void OnCardUse()
        {
            OnCardUseAction?.Invoke(this);
        }
    }
}
