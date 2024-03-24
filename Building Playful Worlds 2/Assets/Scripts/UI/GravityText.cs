using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityText : MonoBehaviour
{
    public TMP_Text text;

    public void ChangeText(string gravityMode)
    {
        text.SetText("Gravity : " + gravityMode);
    }
}
