using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using Vuforia;

public class ARController : MonoBehaviour, ITrackableEventHandler
{

    #region Vuforia Components
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    #endregion

    public TrackableBehaviour puzzleTrack;

    public Camera cam;
    public Transform[] waypoints = new Transform[4];
    public GameObject capsula;
    
    public int speed;
    int currentPoint;
    public GameObject Botones;
    /*public GameObject minijuegoMariposa;
    public GameObject minijuegoDonald;
    public GameObject minijuegoMickey;
*/
    float valor;

    Ray ray;
    RaycastHit rayHit;

    enum estadosPuzzle { CaraMickey, CaraMickeyFeliz, CaraMickeyGrosero, CaraQR, CaraMariposa, CaraDonald, Null}
    estadosPuzzle statusPuzzle = estadosPuzzle.Null; 

    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = puzzleTrack;
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        Botones.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        RayClick();
    }

   

    void RayClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickey")))
            {
                //minijuegoMickey.SetActive(true);
                statusPuzzle = estadosPuzzle.CaraMickey;
                for (int i = 0; i < waypoints.Length; i++)
                {
                    if (capsula.transform.position == waypoints[currentPoint].position)
                    {
                        currentPoint = (currentPoint + 1) % waypoints.Length;
                    }
                }
                capsula.transform.position = Vector3.MoveTowards(capsula.transform.position, waypoints[currentPoint].position, speed * Time.deltaTime);
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraQR")))
            {
                statusPuzzle = estadosPuzzle.CaraQR;

                Debug.Log("CaraQR");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickeyFeliz")))
            {

                statusPuzzle = estadosPuzzle.CaraMickeyFeliz;
                Debug.Log("CaraMickeyFeliz");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickeyGrosero")))
            {
                statusPuzzle = estadosPuzzle.CaraMickeyGrosero;
                Debug.Log("CaraMickeyGrosero");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraDonald")))
            {
                statusPuzzle = estadosPuzzle.CaraDonald;
                //minijuegoDonald.SetActive(true);
                Botones.SetActive(true);
                MinijuegoDonald(valor);
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMariposa")))
            {
                statusPuzzle = estadosPuzzle.CaraMariposa;
                //minijuegoMariposa.SetActive(true);
                Debug.Log("CaraMariposa");
            }

        }
    }

    public void MinijuegoDonald(float _valor)
    {
        
        GameObject cubo = GameObject.Find("CuboAzul");
        Vector3 cuboScale = cubo.transform.localScale;
        cuboScale.x += _valor;
        cuboScale.y += _valor;
        cuboScale.z += _valor;
        cubo.transform.localScale = cuboScale;
    }

  


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (statusPuzzle==estadosPuzzle.CaraDonald)
            {
                Botones.SetActive(true);
                //minijuegoDonald.SetActive(true);
            }
           
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
           // Botones.SetActive(false);
            //minijuegoMariposa.SetActive(false);
            //minijuegoMickey.SetActive(false);
        }
        else
        {
            Botones.SetActive(false);
            
        }
    }
}

