using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class ImgVideo : MonoBehaviour
{

    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;

    public Animator anim;

    public bool videoPlaying = false;

    public GameObject RefBut;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
        RefBut.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {


        if (statusImg.isDetected && !videoPlaying) {
            Debug.Log("inicia video");
            PlayButtom();
            anim.SetBool("Video_Action", true);
            RefBut.SetActive(true);
        }
        else if (!statusImg.isDetected) {
            Debug.Log("pausa video");
            PauseButtom();
            anim.SetBool("Video_Action",false);
            RefBut.SetActive(false);
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
