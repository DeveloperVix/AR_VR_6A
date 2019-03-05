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


    private void Update()
    {
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("inicia video");
            Playbutton();
        }
        else if (!statusImg.isDetected)
        {
            Debug.Log("Pauso video");
            PauseButton();
            anim.SetBool("Transicion", false);
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
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            Debug.Log("inicia video");
            Playbutton();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            Debug.Log("Pauso video");
            PauseButton();
            anim.SetBool("Transicion", false);
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
        }
    }

    public void Playbutton()
    {
        miVidio.Play();
        anim.SetBool("Transicion", true);
        Debug.Log("Playyyyyyy");
        videoPlaying = true;
    }

    public void PauseButton()
    {
        miVidio.Pause();
        
        videoPlaying = false;
    }
}
