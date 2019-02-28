using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SphereScript : MonoBehaviour
{
    Camera thisCamera;

    Vector3 initialMousePos;
    Vector3 finalMousePos;

    public AudioSource audioSound;

    void Awake()
    {
        thisCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePos = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {
                audioSound.Play();
                Debug.Log("Toco objeto");
            }
        }
    }

}
