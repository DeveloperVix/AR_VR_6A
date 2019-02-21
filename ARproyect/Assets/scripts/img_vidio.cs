using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class img_vidio : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVidio;

    bool videoPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    void Update()
    {
        if(statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia vidio v:");
            Playbutton();
        }
        else if(!statusImg.isDetected)
        {
            Debug.Log("Pausa vidio :v");
            Pausebutton();
        }
    }

    public void Playbutton()
    {
        miVidio.Play();
        videoPlaying = true;
    }

    public void Pausebutton()
    {
        miVidio.Pause();
        videoPlaying = false;
    }
}
