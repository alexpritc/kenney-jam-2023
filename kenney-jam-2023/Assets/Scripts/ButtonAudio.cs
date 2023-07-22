using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DefaultAudio : MonoBehaviour, IPointerClickHandler

{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager.Instance.PlayAudio(1);
    }
}
