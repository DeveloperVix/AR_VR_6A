using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;


public class IMGvideo : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    private void Update()
    {
        if (statusImg.isDetected)
        {
            Debug.Log("Inicia Cuenta regresiva");
            miVideo.Play();
        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Detener cuenta regresiva");
            miVideo.Pause();
        }

    }
}