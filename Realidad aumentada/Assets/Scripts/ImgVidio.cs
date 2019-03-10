using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;//libreria para modificar videoplayer
using Vuforia;

public class ImgVidio : MonoBehaviour, ITrackableEventHandler
{

    protected TrackableBehaviour mTrackableBehaviour;
    public Animator anim;
    public DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVidio;

    bool videoPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            Debug.Log("inicia video");
            Playbutton();

            anim.SetBool("Transicion", true);
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Pauso video");
            PauseButton();
            anim.SetBool("Transicion", false);
        }
    }

    public void Playbutton()
    {
        miVidio.Play();
        Debug.Log("Playyyyyyy");
        videoPlaying = true;
    }

    public void PauseButton()
    {
        miVidio.Pause();
        
        videoPlaying = false;
    }
}
