using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class SnarkyCommentManager : MonoBehaviour
{
    public bool isSnarky;

    float timer = 0f;

    public TextMeshProUGUI text;
    public TextMeshProUGUI comment;

    public string[] comments;


    public void ToggleSnark()
    {
        isSnarky= !isSnarky;

        if (!isSnarky)
        {
            text.text = "Oh no... the play button isn't enabled";
            comment.text = "(maybe you can fix that in the settings menu)";
        }
        if (isSnarky)
        {
            text.text = NewSnarkyComment();
            timer = 0f;
            comment.text = " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        var value = Random.Range(10f, 15f);

        if (isSnarky && timer >= value)
        {
            text.text = NewSnarkyComment();
            timer -= value;
        }
    }

    string NewSnarkyComment()
    {
        string x = "";

        int value = (int)Random.Range(0f, comments.Length);

        if (value == 19)
        {
            int cheat = (int)Random.Range(0f, 101f);
            if (cheat < 100)
            {
                value = 18;
            }
        }

        x = comments[value];

        return x;
    }
}
