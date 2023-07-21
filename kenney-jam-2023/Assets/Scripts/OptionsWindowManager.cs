using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsWindowManager : MonoBehaviour
{
    public GameObject[] headerButtons;
    private GameObject currentButton;

    public Sprite defaultSprite;
    public Sprite selectedSprite;

    private void Start()
    {
        currentButton = headerButtons[0];
        currentButton.GetComponent<Image>().sprite = selectedSprite;
    }

    public void UpdateCurrentButton(GameObject go)
    {
        currentButton = go;

        foreach (var button in headerButtons) { 

            if (button == currentButton) {
                button.GetComponent<Image>().sprite = selectedSprite;
            }
            else
            {
                button.GetComponent<Image>().sprite = defaultSprite;
            }
        }
    }
}
