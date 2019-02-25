using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VideoScript : MonoBehaviour
{
    DefaultTrackableEventHandler Statusimg;
    public VideoPlayer VideoPlayer;
    bool OnPlays = false;

        void Start()
    {
        Statusimg = GetComponent<DefaultTrackableEventHandler>();
    }
    
    private void Update()
    {
        if(Statusimg.isDetected && !OnPlays){
            playButton();
        }
        else if (!Statusimg.isDetected)
        {
            pauseButton();
        }
    }
    public void playButton()
    {
        VideoPlayer.Play();
        OnPlays = false;
    }
    public void pauseButton()
    {
        VideoPlayer.Pause();
        OnPlays = true;
    }
}
