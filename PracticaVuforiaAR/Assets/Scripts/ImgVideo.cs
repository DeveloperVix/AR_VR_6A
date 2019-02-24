using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;


public class ImgVideo : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;
    public Animator animator;

    public bool videoPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia Video");
            PlayButton();
            animator.SetBool("Playing", true);

        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Pausa Video");
            PauseButton();
            animator.SetBool("Playing", false);
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
