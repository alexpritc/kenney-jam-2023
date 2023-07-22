using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite selectedSprite;

    public GameObject menu;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleEffect(string effectName)
    {
        GameManager.Instance.ToggleEffect(effectName);
    }

    public void EnableGameObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void DisableGameObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void Select()
    {
        GetComponent<Image>().sprite = selectedSprite;
        menu.SetActive(true);
    }

    public void Deselect()
    {
        GetComponent<Image>().sprite = defaultSprite;
        menu.SetActive(false);
    }
}
