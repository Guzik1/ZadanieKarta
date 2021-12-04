using Assets.Scripts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
    public Image Icon;
    [HideInInspector] public CardEffect UseEffect;
    [HideInInspector] public Action<CardController> OnCardUseAction;

    public void SetNewData(string title, string decription, Sprite icon, CardEffect useEffect)
    {
        TitleText.text = title;
        DescriptionText.text = decription;
        Icon.sprite = icon;
        UseEffect = useEffect;
    }

    public void OnCardUse()
    {
        OnCardUseAction?.Invoke(this);
    }
}
