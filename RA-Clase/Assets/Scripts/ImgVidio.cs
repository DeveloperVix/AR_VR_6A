using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using Vuforia;

public class ImgVidio : MonoBehaviour
{

    DefaultTrackableEventHandler statusImg;
    public VideoPlayer miVidio;
    public GameObject UIuser;

    bool videoPlaying = false;

    


    // Start is called before the first frame update
    void Start()
    {
        
        statusImg = GetComponent<DefaultTrackableEventHandler>();

        

        
    }

    private void Update()
    {
        Animator anim = UIuser.GetComponent<Animator>();
        bool IsPlaying = anim.GetBool("IsPlaying");
        if (statusImg.isDetected && !videoPlaying)
        {
            Debug.Log("Inicia vidio");
            miVidio.Play();
            anim.SetBool("IsPlaying", IsPlaying = true);
        }
        else if(!statusImg.isDetected)
        {
            Debug.Log("Pausa vidio");
            miVidio.Stop();
            anim.SetBool("IsPlaying", IsPlaying = false);
        }
    }

    public void PlayButton()
    {
        Debug.Log("Boton presionado Play");
        miVidio.Play();
        videoPlaying = true;
    }

    public void PauseButton()
    {
        Debug.Log("Boton presionado Pausa");
        miVidio.Pause();
    }



    /* RESPALDO
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }
    */
}
