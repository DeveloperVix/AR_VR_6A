using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SecuenseController : MonoBehaviour, ITrackableEventHandler
{

    public List<GameObject> circles;
    private bool flag = false;
    private bool onTrackStay = false;

    private TrackableBehaviour trackableBehaviour;

    void Start()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
            trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (trackableBehaviour)
            trackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    void Update()
    {

    }

    #region VuforiaStatus

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) //No entra a la interfaz
    {
        Debug.Log("asdassd");

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            onTrackingLost();
        }
        else
        {
            onTrackingLost();
        }
    }

    private void OnTrackingFound()
    {
        Debug.Log("track");
        if (flag)
        {
            Debug.Log("Has superado esta prueba");
        }
    }
    private void onTrackingLost()
    {
        Debug.Log("no track");
        if (!flag)
        {
            foreach (GameObject i in circles)
            {
                i.gameObject.SetActive(false);
            }
        }
    }

    #endregion

    public void CheckOrder(int index)
    {

        for(int i = 0; i < index; i++)
        {
            if (!circles[i].gameObject.activeSelf)
            {
                StartCoroutine(WrongOrder());
                break;
            }
            else
            {
                if(index == circles.Count)
                {
                    Debug.Log("Has ganado!!!");
                    flag = true;
                }
            }
        }
    }

    IEnumerator WrongOrder()
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject i in circles)
        {
            i.gameObject.SetActive(false);
        }
    }
}
