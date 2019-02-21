using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class ImgVideo : MonoBehaviour
{

    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;

    bool videoPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    // Update is called once per frame
    private void Update()
    {



        if (statusImg.isDetected && !videoPlaying) {
            Debug.Log("inicia video");
            PlayButtom();
        }
        else if (!statusImg.isDetected) {
            Debug.Log("pausa video");
            PauseButtom();
                }
    }

    public void PlayButtom()
    {
        miVideo.Play();
        videoPlaying = true;
    }

    public void PauseButtom()
    {
        miVideo.Pause();
        videoPlaying = false;
    }

}
