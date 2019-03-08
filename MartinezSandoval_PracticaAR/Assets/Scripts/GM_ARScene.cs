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

    public static GM_ARScene act;

    [Header("General Components")]
    #region General Components
    [Header("Main")]
    public Camera mainCamera;
    public TrackableBehaviour puzzleTrack;
    public GameObject puzzleBayo, puzzleSamus, puzzlePalu, puzzleRosa, puzzleCorrin, puzzlePeach;


    public enum CurrentPuzzle { Null, Bayo, Samus, Palu, Rosa, Corrin, Peach }
    public CurrentPuzzle currentPuzzle = CurrentPuzzle.Null;


    delegate void CurrentPuzzleFunc();
    CurrentPuzzleFunc currentPuzzleFunc;
    [Header("Prefabs")]
    public GameObject prefabBayo;
    public GameObject prefabSamus, prefabPalu, prefabRosa, prefabCorrin, prefabPeach;
    [HideInInspector]
    public GameObject prefabCurrent;
    [HideInInspector]
    public GameObject currentUI;

    #endregion

    [Header("Bayo Components")]
    #region PuzzleBayo Vars
    public GameObject bayoUI;
    public float[] bayoPosX;
    public float[] bayoPosZ;
    public Vector2 bayoCurrentPos = Vector3.zero;
    [HideInInspector]
    public bool bayoMove;
    [HideInInspector]
    Vector3 bayoNewPos;
    #endregion

    [Header("Samus Components")]
    #region PuzzleSamus Vars
    public GameObject samusUI;
    Transform samusSphere;
    public int samusScaleToWin;

    #endregion

    public GameObject corrinUI;

    [Header("Win")]
    public GameObject objWin;


    Ray ray;
    RaycastHit rayHit;
    
    // Use this for initialization
    void Start ()
    {
        act = this;
        mTrackableBehaviour = puzzleTrack;
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        RayClick();
        if(currentPuzzle != CurrentPuzzle.Null) currentPuzzleFunc();
	}

    #region Puzzle Bayo Functions
    void PuzzleBayo()
    {
        if (objWin.activeInHierarchy) return;
        if(bayoMove)
        {
            print("moving");
            prefabCurrent.transform.GetChild(0).transform.localPosition = Vector3.MoveTowards(prefabCurrent.transform.GetChild(0).transform.localPosition, bayoNewPos, 0.02f);
            if (prefabCurrent.transform.GetChild(0).transform.localPosition == bayoNewPos) bayoMove = false;
            return;
        }
    }

    public void BayoButtonMove(string value)
    {
        if (bayoMove) return;
        print("Move");
        Transform playerPos = prefabCurrent.transform.GetChild(0).transform;
        bayoNewPos = playerPos.localPosition;
        switch (value)
        {
            case "right":
                if(bayoCurrentPos.x != 2)
                {
                    bayoCurrentPos.x++;
                    bayoNewPos.x = bayoPosX[(int)(bayoCurrentPos.x)];
                }
                break;
            case "left":
                if (bayoCurrentPos.x != 0)
                {
                    bayoCurrentPos.x--;
                    bayoNewPos.x = bayoPosX[(int)(bayoCurrentPos.x)];
                }
                break;
            case "down":
                if (bayoCurrentPos.y != 2)
                {
                    bayoCurrentPos.y++;
                    bayoNewPos.z = bayoPosZ[(int)(bayoCurrentPos.y)];
                }
                break;
            case "up":
                if (bayoCurrentPos.y != 0)
                {
                    bayoCurrentPos.y--;
                    bayoNewPos.z = bayoPosZ[(int)(bayoCurrentPos.y)];
                }
                break;
        }

        bayoMove = true;
    }

    #endregion

    #region Puzzle Samus Functions
    void PuzzleSamus()
    {
        if (objWin.activeInHierarchy) return;
        if(samusSphere.localScale.x > 1f)
        {
            Vector3 newScale = samusSphere.localScale;
            float reduceSpeed = 0.08f;
            newScale.x -= reduceSpeed;
            newScale.y -= reduceSpeed;
            newScale.z -= reduceSpeed;
            if(newScale.x < 1)
            {
                newScale.x = 1;
                newScale.y = 1;
                newScale.z = 1;
            }
            samusSphere.localScale = newScale;
        }

        if(samusSphere.localScale.x >= samusScaleToWin)
        {
            objWin.SetActive(true);
        }
    }

    public void SamusButton()
    {
        if (objWin.activeInHierarchy) return;
        Vector3 newScale = samusSphere.localScale;
        float augmentSpeed = 1f;
        newScale.x += augmentSpeed;
        newScale.y += augmentSpeed;
        newScale.z += augmentSpeed;
        samusSphere.localScale = newScale;
    }
    #endregion

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
        if (!Input.GetMouseButtonUp(0)) return;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Bayo")))
        {
            if (currentPuzzle == CurrentPuzzle.Bayo) return;
            HidePuzzles();

            currentUI = bayoUI;
            currentUI.SetActive(true);
            prefabCurrent = Instantiate(prefabBayo, puzzleBayo.transform);

            bayoCurrentPos.x = 1;
            bayoCurrentPos.y = 0;
            currentPuzzleFunc = PuzzleBayo;
            
            currentPuzzle = CurrentPuzzle.Bayo;
            return;
        }

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Corrin")))
        {
            HidePuzzles();

            currentUI = corrinUI;
            currentUI.SetActive(true);
            prefabCurrent = Instantiate(prefabCorrin, puzzleCorrin.transform);

            currentPuzzle = CurrentPuzzle.Corrin;
            
            return;
        }

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Peach")))
        {
            HidePuzzles();
            Instantiate(prefabPeach, puzzlePeach.transform);
            currentPuzzle = CurrentPuzzle.Peach;
            return;
        }

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Samus")))
        {
            if (currentPuzzle == CurrentPuzzle.Samus) return;
            HidePuzzles();
            print("nani");
            currentUI = samusUI;
            currentUI.SetActive(true);
            prefabCurrent = Instantiate(prefabSamus, puzzleSamus.transform);
            samusSphere = prefabCurrent.transform.GetChild(0).transform;
            currentPuzzleFunc = PuzzleSamus;
            currentPuzzle = CurrentPuzzle.Samus;
            return;
        }

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Rosa")))
        {
            HidePuzzles();
            Instantiate(prefabRosa, puzzleRosa.transform);
            currentPuzzle = CurrentPuzzle.Rosa;
            return;
        }

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Palu")))
        {
            HidePuzzles();
            Instantiate(prefabPalu, puzzlePalu.transform);
            currentPuzzle = CurrentPuzzle.Palu;
            return;
        }

    }

    void HidePuzzles()
    {
        objWin.SetActive(false);
        Destroy(prefabCurrent);
        if (currentUI != null)
            currentUI.SetActive(false);
        currentUI = null;
        prefabCurrent = null;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (currentUI != null)
                currentUI.SetActive(true);
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            if (objWin.activeInHierarchy)
            {
                currentPuzzle = CurrentPuzzle.Null;
                HidePuzzles();
                objWin.SetActive(false);
            }
            if (currentUI != null)
                currentUI.SetActive(false);
        }
        else
        {
            
        }
    }
}