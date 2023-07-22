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
}
