using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;


public class IMGVID : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;
    
    bool videoPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>(); 
        
    }



    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia video :3");
            PlayButton();


        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Pausa Video :c");
            PauseButton();

        }

       

    }

    public void PlayButton()
    {
        miVideo.Play();
        videoPlaying = false;
    }

    public void PauseButton()
    {
        miVideo.Pause();
        videoPlaying = true;
    }

   
}
