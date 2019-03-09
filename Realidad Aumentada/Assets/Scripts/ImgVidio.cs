using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;//libreria para modificar videoplayer
using Vuforia;

public class ImgVidio : MonoBehaviour, ITrackableEventHandler
{
    protected TrackableBehaviour mTrackableBehaviour;
    public GameObject boton;
    public Animator anim;
    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVidio;

    bool videoPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        statusImg = GetComponent<DefaultTrackableEventHandler>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if(mTrackableBehaviour != null)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Inicia video");
            anim.SetBool("isAnimation", true);
            Playbutton();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Pauso video");
            PauseButton();
            anim.SetBool("isAnimation", false);
        }
    }



    public void Playbutton()
    {
        miVidio.Play();
        videoPlaying = true;
    }

    public void PauseButton()
    {
        miVidio.Pause();
        videoPlaying = false;
    }
}
