using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private bool isGravityOn = false;
    public float gravity = -9.81f;

    Rigidbody2D[] allRigidBodies;

    // Spaghetti code, hack
    public GameObject[] checks;
    public Button itchButton;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeGravity(0);
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
        if (input.text.ToUpper() == "TURNIP")
        {
            // Enable itch button
            ToggleButton(itchButton);
            checks[0].SetActive(false);
            checks[1].SetActive(true);
        }
    }

    // --------------------------------- AUDIO STUFF ----------------------------------------
    [SerializeField] private AudioSource uiAudioSource;
    
    /// <summary>
    /// 0 - panel open
    /// 1 - mouse click
    /// 2 - mouse release
    /// 3 - button pressed
    /// </summary>
    [SerializeField] private AudioClip[] _audioClips;


    public void PlayAudio(AudioClip clip)
    {
        //audioSource.clip = clip;
        uiAudioSource.PlayOneShot(clip);
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

        return 1f;
    }
}
