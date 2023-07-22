using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public bool isShaking;

    void Awake()
    {
        shakeAmount = 0f;
        isShaking = false;

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (!isShaking)
        {
            camTransform.localPosition = originalPos;
            return;
        }

        camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }
    public void UpdateValueOnChange(float value)
    {
        shakeAmount = value;

        if (value > 0f)
        {
            isShaking = true;
        }
        else
        {
            isShaking= false;
        }
    }
}