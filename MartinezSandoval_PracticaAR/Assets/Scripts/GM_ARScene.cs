using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GM_ARScene : MonoBehaviour, ITrackableEventHandler
{

    #region Vuforia Components
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    #endregion

    public TrackableBehaviour puzzleTrack;
    public GameObject puzzleBayo, puzzleSamus, puzzlePalu, puzzleRosa, puzzleCorrin, puzzlePeach;
    public enum CurrentPuzzle { Null, Bayo, Samus, Palu, Rosa, Corrin, Peach }
    CurrentPuzzle currentPuzzle = CurrentPuzzle.Null;
    
    public GameObject prefabBayo, prefabSamus, prefabPalu, prefabRosa, prefabCorrin, prefabPeach;

    [Header("Bayo Components")]
    #region PuzzleBayo Vars
    public float[] bayoPosX;
    public float[] bayoPosY;
    #endregion


    Ray ray;
    RaycastHit rayHit;
    
    // Use this for initialization
    void Start ()
    {
        mTrackableBehaviour = puzzleTrack;
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        RayClick();
	}

    public void GoToScene(string scene)
    {
        GameController.act.LoadNewScene(scene);
    }

    public void StopAllPuzzles()
    {
        HidePuzzles();
    }

    void RayClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Bayo")))
        {
            HidePuzzles();
            Instantiate(prefabBayo, puzzleBayo.transform);
            currentPuzzle = CurrentPuzzle.Bayo;
            return;
        }

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Corrin")))
        {
            HidePuzzles();
            Instantiate(prefabCorrin, puzzleCorrin.transform);
            currentPuzzle = CurrentPuzzle.Corrin;
            return;
        }

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Peach")))
        {
            HidePuzzles();
            Instantiate(prefabPeach, puzzlePeach.transform);
            currentPuzzle = CurrentPuzzle.Peach;
            return;
        }

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Samus")))
        {
            HidePuzzles();
            Instantiate(prefabSamus, puzzleSamus.transform);
            currentPuzzle = CurrentPuzzle.Samus;
            return;
        }

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Rosa")))
        {
            HidePuzzles();
            Instantiate(prefabRosa, puzzleRosa.transform);
            currentPuzzle = CurrentPuzzle.Rosa;
            return;
        }

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, LayerMask.GetMask("Palu")))
        {
            HidePuzzles();
            Instantiate(prefabPalu, puzzlePalu.transform);
            currentPuzzle = CurrentPuzzle.Palu;
            return;
        }

    }

    void HidePuzzles()
    {
        switch (currentPuzzle)
        {
            case CurrentPuzzle.Bayo:
                Destroy(puzzleBayo.transform.GetChild(0));
                break;
            case CurrentPuzzle.Samus:
                Destroy(puzzleSamus.transform.GetChild(0));
                break;
            case CurrentPuzzle.Palu:
                Destroy(puzzlePalu.transform.GetChild(0));
                break;
            case CurrentPuzzle.Rosa:
                Destroy(puzzleRosa.transform.GetChild(0));
                break;
            case CurrentPuzzle.Corrin:
                Destroy(puzzleCorrin.transform.GetChild(0));
                break;
            case CurrentPuzzle.Peach:
                Destroy(puzzlePeach.transform.GetChild(0));
                break;
        }
        currentPuzzle = CurrentPuzzle.Null;
    }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {

        }
        else
        {

        }
    }
}