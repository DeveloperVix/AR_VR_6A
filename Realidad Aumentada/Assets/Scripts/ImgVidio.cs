using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;//libreria para modificar videoplayer
using Vuforia;

public class ImgVidio : MonoBehaviour
{
    public Animator anim;
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVidio;

    bool videoPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }


    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia video");
            Playbutton();
            
        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Pauso video");
            PauseButton();
            anim.SetBool("isAnimation", false);
        }

    }

    public void Playbutton()
    {
        miVidio.Play();
        anim.SetBool("isAnimation", true);
        videoPlaying = true;
    }

    public void PauseButton()
    {
        miVidio.Pause();
        videoPlaying = false;
    }
}
