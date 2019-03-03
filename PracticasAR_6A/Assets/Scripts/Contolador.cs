using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Contolador : MonoBehaviour
{
    public GameObject imagen;
    public VideoPlayer video;

    DefaultTrackableEventHandler scriptVuforia;

    public Button play;
    public Button pause; 


    
    // Start is called before the first frame update
    void Start()
    {
        scriptVuforia = imagen.GetComponent<DefaultTrackableEventHandler>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptVuforia.isDetected)
        {
            play.GetComponent<Animator>().Play("play");
            pause.GetComponent<Animator>().Play("pause");
        }
        else if(!scriptVuforia.isDetected)
        {
            play.GetComponent<Animator>().Play("playOut");
            pause.GetComponent<Animator>().Play("pauseOut");
        }

    }

    public void PlayVideo()
    {
        video.Play();
    }
    public void PauseVideo()
    {
        video.Pause();
    }
}
