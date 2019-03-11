using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;
using UnityEngine.UI;

public class video : MonoBehaviour
{
    DefaultTrackableEventHandler statusIMG;
    public VideoPlayer mividio;
    bool videoPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        statusIMG = GetComponent<DefaultTrackableEventHandler>();
    }

    private void Update()
    {
        if (statusIMG.isDetected && !videoPlaying)
        {
            //Debug.Log("INICIA VIDEO lel");
            PlayButton();
        }
        else if (!statusIMG.isDetected)
        {
            //Debug.Log("PAUSA VIDEO QUE SI");
            PauseButton();
        }
    }

    public void PlayButton()
    {
        mividio.Play();
        videoPlaying = true;
    }

    public void PauseButton()
    {
        mividio.Pause();
        videoPlaying = false;
    }

    // Update is called once per frame



    
}
