using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;


public class video : MonoBehaviour
{
    public DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVideo;
    public Animator animacion_botones;
    bool videoPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        //statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia Video");
            PlayButton();
            animacion_botones.SetBool("vista",true);
        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Pausa Video");
            PauseButton();
            animacion_botones.SetBool("vista", false);
        }
    }

    public void PlayButton()
    {
        miVideo.Play();
        videoPlaying = true;
    }
    public void PauseButton()
    {
        Debug.Log("entra o que pez");
        miVideo.Pause();
        videoPlaying = false;
    }

    public void boton_pausa()
    {
        miVideo.Pause();
    }

}

//poner los eventos a los botones
//animar los cuadros para que cuando detecten el target y se entren en la escena
//implementacion de ux
