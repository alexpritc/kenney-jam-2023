using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioManager : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    public AudioMixer mixer;
    public string volName;

    private void Awake()
    {
        slider.value = GameManager.Instance.GetVolume(volName);
    }

    public void UpdateValueOnChange(float value)
    {
        mixer.SetFloat(volName, Mathf.Log(value) * 20f);
        GameManager.Instance.UpdateVolumeSlider(volName, value);
    }
}