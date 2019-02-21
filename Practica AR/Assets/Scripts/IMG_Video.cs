using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; //Libreria para modificar VIDEOPLAYER
using Vuforia;//Libreria de Vuforia :v
public class IMG_Video : MonoBehaviour
{
    public DefaultTrackableEventHandler statusIMG;
    public VideoPlayer miVideo;
    bool videoIsPlay = false;
    public Animator animaciones;

    void Start()
    {
        //statusIMG = GetComponent<DefaultTrackableEventHandler>();
       //animaciones = GetComponent<Animator>();
    }

    private void Update()
    {
        if (statusIMG.isDetected && !videoIsPlay)
        {
            Debug.Log("Inicia Video :v");
            PlayButton();
            
        }
        else if (!statusIMG.isDetected)
        {
            Debug.Log("Pausa Video :y");
            PauseButton();
            animaciones.SetBool("activo", false);
        }
    }

    public void PlayButton()
    {
        miVideo.Play();
        animaciones.SetBool("activo", true);
        videoIsPlay = true;
        //animaciones.Play("Entrada");
    }

    public void PauseButton()
    {
        miVideo.Pause();
        videoIsPlay = false;

    }
}
