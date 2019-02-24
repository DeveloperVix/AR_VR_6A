using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VideoPanelScript : MonoBehaviour//, ITrackableEventHandler
{

    /*protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;*/

    public GameObject panelVideo;
    public GameObject controlsVideo;
    public VideoPlayer videoSource;

    public bool asd;
    public float mainPosition;

    // Start is called before the first frame update
    void Start()
    {
        asd = true;
        mainPosition = controlsVideo.transform.position.x;
    }

    private void Update()
    {
        if(DefaultTrackableEventHandler.flag && asd)
        {
            asd = false;
            StartCoroutine(EnterAnimation());
        }
        else if(!DefaultTrackableEventHandler.flag)
        {
            StopAllCoroutines();
            controlsVideo.transform.position = new Vector3(mainPosition, controlsVideo.transform.position.y, controlsVideo.transform.position.z);
            asd = true;
            PauseVideo();
        }
    }

    /*public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {

        Debug.Log("Cambio estado");
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            EnterAnimation();
            PlayVideo();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {

            PauseVideo();
        }
        else
        {

            PauseVideo();
        }
    }*/

    public void PlayVideo()
    {
        videoSource.Play();
    }

    public void PauseVideo()
    {
        videoSource.Pause();
    }

    /*public void EnterAnimation()
    {
        controlsVideo.transform.position = new Vector3 (controlsVideo.transform.position.x - 125f , controlsVideo.transform.position.y, controlsVideo.transform.position.z);
        while (controlsVideo.transform.position.x <= 0)
        {
            controlsVideo.transform.position = new Vector3(controlsVideo.transform.position.x + 5, controlsVideo.transform.position.y, controlsVideo.transform.position.z);
        }
    }*/

    IEnumerator EnterAnimation()
    {
        controlsVideo.transform.position = new Vector3(controlsVideo.transform.position.x - 125f, controlsVideo.transform.position.y, controlsVideo.transform.position.z);
        while (controlsVideo.transform.position.x <= mainPosition)
        {
            controlsVideo.transform.position = new Vector3(controlsVideo.transform.position.x + 5, controlsVideo.transform.position.y, controlsVideo.transform.position.z);
            yield return new WaitForSeconds(.05f);
        }
        PlayVideo();
        yield return null;
    }
}
