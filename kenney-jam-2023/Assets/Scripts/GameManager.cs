using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Button PlayButton;

    private bool isGravityOn = false;
    public float gravity = -9.81f;

    Rigidbody2D[] allRigidBodies;

    // Spaghetti code, hack
    public GameObject[] checks;
    public Button itchButton;

    private string currentPasswordAttempt = "";

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeGravity(0);
    }

    private void Update()
    {
        KeyLogger();
    }


    // --------------------------------- GAMEPLAY PUZZLE STUFF ----------------------------------------
    public void ToggleGravity()
    {
        isGravityOn = !isGravityOn;
        ChangeGravity(isGravityOn ? gravity : 0);

        // reset velocity
        if (!isGravityOn)
        {
            // yuck
            allRigidBodies = (Rigidbody2D[])FindObjectsOfType(typeof(Rigidbody2D));
            foreach (var rb in allRigidBodies)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void ChangeGravity(float gravityScale)
    {
        Physics2D.gravity = new Vector3(0, gravityScale, 0);
    }

    public void ToggleButton(Button button)
    {
        button.interactable = !button.IsInteractable();
    }

    public void CheckPassword(TMP_InputField input)
    {
        GameManager.Instance.PlayAudio(1);

        if (input.text.ToUpper() == "TURNIP")
        {
            // Enable itch button
            itchButton.interactable = true;
            checks[0].SetActive(false);
            checks[1].SetActive(true);
        }
    }

    public void KeyLogger()
    {
        if (currentPasswordAttempt.Length >= 9)
        {
            currentPasswordAttempt = currentPasswordAttempt.Remove(0, 1);
        }

        foreach (char c in Input.inputString)
        {
            currentPasswordAttempt += c;
        }

        if (string.Equals(currentPasswordAttempt, "kenneyjam", StringComparison.OrdinalIgnoreCase))
        {
            ActivatePlayButton();
        }
    }

    private void ActivatePlayButton()
    {
        PlayButton.interactable = true;
        PlayAudio(4);
    }

    // --------------------------------- AUDIO STUFF ----------------------------------------
    [SerializeField] private AudioSource uiAudioSource;

    /// <summary>
    /// 0 - panel open
    /// 1 - mouse hover
    /// 2 - mouse release
    /// 3 - button pressed
    /// 4 - start button unlocked
    /// </summary>
    [SerializeField] private AudioClip[] audioClips;
    public void PlayAudio(int clip)
    {
        uiAudioSource.PlayOneShot(audioClips[clip]);
    }

    // for keeping track of it
    private float masterVol = 1f;
    private float musicVol = 1f;
    private float SFXVol = 1f;

    public void UpdateVolumeSlider(string mixer, float vol)
    {
        switch (mixer)
        {
            case "Master":
                masterVol = vol;
                break;
            case "Music":
                musicVol = vol;
                break;
            case "SFX":
                SFXVol = vol;
                break;
        }
    }

    public float GetVolume(string mixer)
    {
        switch (mixer)
        {
            case "Master":
                return masterVol;
            case "Music":
                return musicVol;
            case "SFX":
                return SFXVol;
        }

        return 0f;
    }
}
