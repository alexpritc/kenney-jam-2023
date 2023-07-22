using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private bool isGravityOn = false;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeGravity(0);
    }

    public void ToggleEffect(string effectName)
    {

    }

    public void ToggleGravity()
    {
        isGravityOn = !isGravityOn;
        ChangeGravity(isGravityOn ? -9.81f : 0);
    }

    public void ChangeGravity(float gravityScale)
    {
        Physics2D.gravity = new Vector3(0, gravityScale, 0);
    }
}
