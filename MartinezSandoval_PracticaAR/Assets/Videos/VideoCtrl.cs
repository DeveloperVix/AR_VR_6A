using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VideoCtrl : MonoBehaviour, ITrackableEventHandler
{
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    [SerializeField]
    VideoPlayer videoPlayer;
    //public bool isDetected;
    public Animator animator;

    // Use this for initialization
    void Start ()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void HideController()
    {
        animator.Play("Controles_Hide");
    }

    void ShowController()
    {
        animator.Play("Controles_Show");
    }

    public void PlayButton()
    {
        videoPlayer.Play();
    }

    public void PauseButton()
    {
        videoPlayer.Pause();
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            videoPlayer.Play();
            ShowController();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            videoPlayer.Stop();
            HideController();
        }
        else
        {
            videoPlayer.Stop();
            HideController();
        }
    }
}
