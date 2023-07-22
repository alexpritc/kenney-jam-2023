using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsWindowManager : MonoBehaviour
{
    public ButtonController[] headerButtons;
    private ButtonController currentButton;

    private void Start()
    {
        currentButton = headerButtons[0];
        currentButton.Select();
    }

    public void UpdateCurrentButton(ButtonController buttonToUpdate)
    {
        currentButton = buttonToUpdate;

        foreach (var button in headerButtons)
        {
            if (button == currentButton)
            {
                button.Select();
            }
            else
            {
                button.Deselect();
            }
        }
    }
}
