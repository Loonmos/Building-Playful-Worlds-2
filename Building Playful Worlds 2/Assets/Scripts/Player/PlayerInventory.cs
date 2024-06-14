using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI crystalText;

    public int crystalAmount;

    void Start()
    {
        crystalAmount = 0;
        crystalText.SetText("Crystals : " + crystalAmount);
    }

    public void AddCrystal()
    {
        crystalAmount ++;
        crystalText.SetText("Crystals : " + crystalAmount);
    }

    public void RemoveCrystal()
    {
        crystalAmount--;
        crystalText.SetText("Crystals : " + crystalAmount);
    }
}
