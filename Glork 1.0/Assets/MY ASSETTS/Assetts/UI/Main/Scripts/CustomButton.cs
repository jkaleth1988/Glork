using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomButton : MonoBehaviour
{

    public Button button; // Drag & Drop the button in the inspector

    public void TurnRed()
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        button.colors = colors;
    }

    public void TurnWhite()
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(225, 225, 225, 255);
        button.colors = colors;
    }
}