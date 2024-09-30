using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField]
    private Image iconImage,backImage;

    public void Show(CardModel cardModel)
    {
        iconImage.sprite = cardModel.icon;
        backImage.sprite = cardModel.backicon;

        iconImage.gameObject.SetActive(true);
        backImage.gameObject.SetActive(false);
    }

    public void ShowBack(CardModel cardModel)
    {
        iconImage.sprite = cardModel.icon;
        backImage.sprite = cardModel.backicon;

        backImage.gameObject.SetActive(true);
    }
}
