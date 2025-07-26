using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChipSelectHistoryView : View
{
    [SerializeField] private List<ChipSelectHistory> chipSelectHistories = new List<ChipSelectHistory>();
    [SerializeField] private Image imageNumber;
    [SerializeField] private TextMeshProUGUI textNumber;

    public void Activate(int number)
    {
        var chipSelect = GetSpriteColor(number);

        if(chipSelect == null)
        {
            Deactivate();
            return;
        }

        imageNumber.gameObject.SetActive(true);
        textNumber.text = number.ToString();
        imageNumber.sprite = chipSelect.SpriteColor;
    }

    public void Deactivate()
    {
        imageNumber.gameObject.SetActive(false);
    }

    private ChipSelectHistory GetSpriteColor(int number)
    {
        return chipSelectHistories.FirstOrDefault(data => data.Number == number);
    }
}

[System.Serializable]
public class ChipSelectHistory
{
    [SerializeField] private int number;
    [SerializeField] private Sprite spriteColor;

    public int Number => number;
    public Sprite SpriteColor => spriteColor;
}
