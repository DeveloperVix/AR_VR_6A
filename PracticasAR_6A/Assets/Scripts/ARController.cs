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
    public GameObject TitulosQR;
    public GameObject ImagenesDiferencias;
    public GameObject GANASTE;
    public GameObject RotacionPuzzle;
    public Transform CuboPuntero;
    public GameObject CuboDonald;
    public GameObject JuegoEsfera;
    public GameObject CapsulaMickey;
    public GameObject nivel;
    
    /*public GameObject minijuegoMariposa;
    public GameObject minijuegoDonald;
    public GameObject minijuegoMickey;
*/
    int valor;
    int _valor;
    string op;
    int direccion;
    Rigidbody EsferaRB;

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
        TitulosQR.SetActive(false);
        ImagenesDiferencias.SetActive(false);
        CuboDonald.SetActive(false);
        
        CapsulaMickey.SetActive(false);
        RotacionPuzzle.SetActive(false);

        EsferaRB.constraints = RigidbodyConstraints.FreezeAll;
        
        nivel.SetActive(false);
        
        
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
                CapsulaMickey.SetActive(true);
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
                TitulosQR.SetActive(true);
                ImagenesDiferencias.SetActive(true);
                Diferencias(op);
                Debug.Log("CaraQR");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickeyFeliz")))
            {

                statusPuzzle = estadosPuzzle.CaraMickeyFeliz;
                RotacionPuzzle.SetActive(true);
                Rotacion(direccion);
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
                CuboDonald.SetActive(true);
                // MinijuegoDonald(valor);
               // Aumento(valor);
                //Decremento(_valor);
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMariposa")))
            {
                statusPuzzle = estadosPuzzle.CaraMariposa;
                EsferaRB =JuegoEsfera.GetComponent<Rigidbody>();
                EsferaRB.useGravity = true;
                nivel.SetActive(true);
                //MiniJuegoEsfera();
                Debug.Log("CaraMariposa");
            }

        }
    }

  /*  public void MinijuegoDonald(float _valor)
    {
        
        GameObject cubo = GameObject.Find("CuboAzul");
        Vector3 cuboScale = cubo.transform.localScale;
        if (_valor > 0)
        {
            Debug.Log("Mas");
            cuboScale.x += _valor;
            cuboScale.y += _valor;
            cuboScale.z += _valor;
        }
        else
        {
            Debug.Log("MENOS");
            cuboScale.x -= _valor;
            cuboScale.y -= _valor;
            cuboScale.z -= _valor;
        }
        cubo.transform.localScale = cuboScale;
    }
    */
    public void Aumento(int valor)
    {
        Debug.Log("MAs");
        GameObject cubo = GameObject.Find("CuboAzul");
         Vector3 cuboScale = cubo.transform.localScale;
        cuboScale.x += valor;
        cuboScale.y += valor;
        cuboScale.z += valor;
        cubo.transform.localScale = cuboScale;
    }
    public void Decremento(int _valor)
    {
        Debug.Log("Menos");
        GameObject cubo = GameObject.Find("CuboAzul");
        Vector3 cuboScale = cubo.transform.localScale;
        cuboScale.x -= _valor;
        cuboScale.y -= _valor;
        cuboScale.z -= _valor;
        cubo.transform.localScale = cuboScale;
    }

    public void Diferencias(string op)
    {
        Vector3 cuboTranslacion = CuboPuntero.transform.position;
        switch (op)
        {
            case "up":
                cuboTranslacion.x += 0;
                cuboTranslacion.y += 0;
                cuboTranslacion.z += .05f;
                break;
            case "down":
                cuboTranslacion.x += 0;
                cuboTranslacion.y += -0;
                cuboTranslacion.z += -.05f;
                break;
            case "left":
                cuboTranslacion.x += -.05f;
                cuboTranslacion.y += 0;
                cuboTranslacion.z += 0;
                break;
            case "right":
                cuboTranslacion.x += .05f;
                cuboTranslacion.y += 0;
                cuboTranslacion.z += 0;
                break;
            default:
                return;
              
        }
        CuboPuntero.transform.position = cuboTranslacion;


    }

   /* public void MiniJuegoEsfera()
    {
        if(GANASTE.activeInHierarchy || m_NewStatus == TrackableBehaviour.Status.NO_POSE)
        {
            EsferaRB.constraints = RigidbodyConstraints.FreezeAll;
            
        }
        else
        {
            if(EsferaRB.constraints == RigidbodyConstraints.FreezeAll)
            {
                EsferaRB.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }
    */

    public void Rotacion(int direccion)
    {
        GameObject eje = GameObject.Find("Eje");

        Debug.Log(direccion);
        eje.transform.Translate(0, 0, 0);
        eje.transform.Rotate(0, direccion, 0);
        direccion += direccion;

        
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
                CuboDonald.SetActive(true);
                //minijuegoDonald.SetActive(true);
            }
            if (statusPuzzle == estadosPuzzle.CaraQR)
            {
                TitulosQR.SetActive(true);
                ImagenesDiferencias.SetActive(true);
            }
            if (statusPuzzle == estadosPuzzle.CaraMariposa)
            {
                
                nivel.SetActive(true);
                
                EsferaRB.useGravity = true;
            }
            if(statusPuzzle == estadosPuzzle.CaraMickey)
            {
                CapsulaMickey.SetActive(true);
                
            }
            if (statusPuzzle == estadosPuzzle.CaraMickeyGrosero)
            {
                
            }
            if (statusPuzzle == estadosPuzzle.CaraMickeyFeliz)
            {
                RotacionPuzzle.SetActive(true);
            }

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Botones.SetActive(false);
            CuboDonald.SetActive(false);
            //minijuegoMariposa.SetActive(false);
            //minijuegoMickey.SetActive(false);
            TitulosQR.SetActive(false);
            ImagenesDiferencias.SetActive(false);
            JuegoEsfera.SetActive(false);
            CapsulaMickey.SetActive(false);
           // EsferaRB.constraints = RigidbodyConstraints.FreezeAll;
            //EsferaRB.useGravity = false;
            RotacionPuzzle.SetActive(false);

        }
        else
        {
            Botones.SetActive(false);
            TitulosQR.SetActive(false);
            ImagenesDiferencias.SetActive(false);
            CuboDonald.SetActive(false);
            JuegoEsfera.SetActive(false);
            CapsulaMickey.SetActive(false);
            EsferaRB.constraints = RigidbodyConstraints.FreezeAll;
            EsferaRB.useGravity = false;
            //nivel.SetActive(false);
            RotacionPuzzle.SetActive(false);
        }
    }
}

