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
    public GameObject puzzleBayo, puzzleSamus, puzzlePalu, puzzleBowser, puzzleDaisy, puzzlePit;


    public enum CurrentPuzzle { Null, Bayo, Samus, Palu, Daisy, Bowser, Pit }
    public CurrentPuzzle currentPuzzle = CurrentPuzzle.Null;


    delegate void CurrentPuzzleFunc();
    CurrentPuzzleFunc currentPuzzleFunc;
    [Header("Prefabs")]
    public GameObject prefabBayo;
    public GameObject prefabSamus, prefabPalu, prefabBowser, prefabDaisy, prefabPit;
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
    [Header("Pit Components")]
    #region PuzzlePit Vars
    public GameObject pitUI;
    Rigidbody pitSphereRB;
    Vector3 pitLastPos;
    #endregion
    [Header("Palu Components")]
    #region PuzzlePalu Vars
    public GameObject paluUI;
    Transform paluSphere;
    #endregion

    public GameObject daisyUI;

    [Header("Win")]
    public GameObject objWin;

    //Ray ray;
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
        if(currentPuzzleFunc != null) currentPuzzleFunc();
	}

    #region Puzzle Bayo Functions
    void PuzzleBayo()
    {
        if (objWin.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE) return;
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
        if (objWin.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE) return;
        if(samusSphere.localScale.x > 1f)
        {
            Vector3 newScale = samusSphere.localScale;
            float reduceSpeed = 0.02f;
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
        float augmentSpeed = 0.24f;
        newScale.x += augmentSpeed;
        newScale.y += augmentSpeed;
        newScale.z += augmentSpeed;
        samusSphere.localScale = newScale;
    }

    #endregion

    #region Puzzle Pit Functions
    void PuzzlePit()
    {
        if (objWin.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE)

        {
            print("do freeze all");
            pitSphereRB.constraints = RigidbodyConstraints.FreezeAll;
            if (pitLastPos == Vector3.zero) pitLastPos = pitSphereRB.gameObject.transform.position;
        }
        else
        {
            if (pitSphereRB.constraints == RigidbodyConstraints.FreezeAll)
            {
                print("undo freeze all");
                pitSphereRB.constraints = RigidbodyConstraints.FreezeRotation;
                pitLastPos = Vector3.zero;
            }
            
        }
    }
    #endregion

    #region Puzzle Palu Functions
    void PuzzlePalu()
    {
        if (objWin.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE) return;

        if (paluSphere.rotation.eulerAngles.y != 0)
        {
            Quaternion rotate = paluSphere.rotation;
            rotate.y += Quaternion.Euler(0, 0.05f, 0).y;
            paluSphere.rotation = rotate;
        }

        if(paluSphere.rotation.eulerAngles.y >= 355f)
        {
            objWin.SetActive(true);
        }
    }

    public void PaluButton()
    {
        if (objWin.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE) return;
        Quaternion rotate = paluSphere.rotation;
        rotate.y -= Quaternion.Euler(0, 25f, 0).y;
        paluSphere.rotation = rotate;
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
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {
                if (rayHit.transform.gameObject == puzzleBayo)
                {
                    if (currentPuzzle == CurrentPuzzle.Bayo) return;
                    HidePuzzles();
                    print("Bayo");
                    currentUI = bayoUI;
                    currentUI.SetActive(true);
                    prefabCurrent = Instantiate(prefabBayo, puzzleBayo.transform);

                    bayoCurrentPos.x = 1;
                    bayoCurrentPos.y = 0;
                    currentPuzzleFunc = PuzzleBayo;
                    bayoMove = false;
                    currentPuzzle = CurrentPuzzle.Bayo;
                    return;
                }

                if (rayHit.transform.gameObject == puzzleSamus)
                {
                    if (currentPuzzle == CurrentPuzzle.Samus) return;
                    HidePuzzles();
                    print("Samus");
                    currentUI = samusUI;
                    currentUI.SetActive(true);
                    prefabCurrent = Instantiate(prefabSamus, puzzleSamus.transform);
                    samusSphere = prefabCurrent.transform.GetChild(0).transform;
                    currentPuzzleFunc = PuzzleSamus;
                    currentPuzzle = CurrentPuzzle.Samus;
                    return;
                }

                if (rayHit.transform.gameObject == puzzleDaisy)
                {
                    HidePuzzles();
                    print("Daisy");
                    currentUI = daisyUI;
                    currentUI.SetActive(true);
                    prefabCurrent = Instantiate(prefabDaisy, puzzleDaisy.transform);

                    currentPuzzle = CurrentPuzzle.Daisy;

                    return;
                }

                if (rayHit.transform.gameObject == puzzlePalu)
                {
                    if (currentPuzzle == CurrentPuzzle.Palu) return;
                    HidePuzzles();
                    print("Palu");
                    prefabCurrent = Instantiate(prefabPalu, puzzlePalu.transform);
                    paluSphere = prefabCurrent.transform.GetChild(0);
                    currentPuzzleFunc = PuzzlePalu;
                    currentPuzzle = CurrentPuzzle.Palu;
                    return;
                }

                if (rayHit.transform.gameObject == puzzlePit)
                {
                    if (currentPuzzle == CurrentPuzzle.Pit) return;
                    HidePuzzles();
                    print("Pit");
                    currentUI = pitUI;
                    currentPuzzleFunc = PuzzlePit;
                    pitUI.SetActive(true);
                    prefabCurrent = Instantiate(prefabPit, puzzlePit.transform);
                    pitSphereRB = prefabCurrent.transform.GetChild(0).GetComponent<Rigidbody>();
                    currentPuzzle = CurrentPuzzle.Pit;
                    return;
                }

                if (rayHit.transform.gameObject == puzzleBowser)
                {
                    HidePuzzles();
                    print("Bowser");
                    Instantiate(prefabBowser, puzzleBowser.transform);
                    currentPuzzle = CurrentPuzzle.Bowser;
                    return;
                }
            }
        }
        
    }

    void HidePuzzles()
    {
        objWin.SetActive(false);
        Destroy(prefabCurrent);
        if (currentUI != null)
            currentUI.SetActive(false);
        currentUI = null;
        currentPuzzleFunc = null;
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
                currentPuzzleFunc = null;
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