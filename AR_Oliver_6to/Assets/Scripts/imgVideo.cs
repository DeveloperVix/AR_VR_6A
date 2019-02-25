using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;
using UnityEngine.UI;

public class imgVideo : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;
    bool videoPlaying = false;
    public Button playButton;
    public Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia Cuenta regresiva");
            //miVideo.Play();
            playButton.onClick.AddListener(PlayButton);
            pauseButton.onClick.AddListener(PauseButton);

        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Detener cuenta regresiva");
            //miVideo.Pause();
        }

    }

    public void PlayButton()
    {
        miVideo.Play();
        videoPlaying = true;
    }

    public void PauseButton()
    {
        miVideo.Pause();
        videoPlaying = false;
    }
}
