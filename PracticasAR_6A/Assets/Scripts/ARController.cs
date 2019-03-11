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
    public Transform[] waypoints2 = new Transform[4];
    public GameObject capsula;
    
    public int speed;
    int currentPoint;
    
    public GameObject TitulosQR;
    public GameObject ImagenesDiferencias;
    public GameObject GANASTE;
    public GameObject RotacionPuzzle;
    public Transform CuboPuntero;
    public GameObject EsferaDonald;
    GameObject Esfera;
    public GameObject CapsulaMickey;
    public GameObject CapsulaRotacion;
    public GameObject nivel;
    public GameObject puzzleRotate;


   
    int valor;
    int _valor;
    string op;
    int direccion;
     Rigidbody EsferaRB;

    float timeNext = 0.3f;
    float fire;

    Ray ray;
    RaycastHit rayHit;

    enum estadosPuzzle { CaraMickey, CaraMickeyFeliz, CaraMickeyGrosero, CaraQR, CaraMariposa, CaraDonald, Null}
    estadosPuzzle statusPuzzle = estadosPuzzle.Null; 

    // Start is called before the first frame update
    void Start()
    {
        Esfera = GameObject.Find("EsferaJuego");
        EsferaRB = Esfera.GetComponent<Rigidbody>();

        EsferaRB.useGravity = false;
        mTrackableBehaviour = puzzleTrack;
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        nivel.SetActive(false); 
        TitulosQR.SetActive(false);
        ImagenesDiferencias.SetActive(false);

        CapsulaRotacion.SetActive(false);
        
        CapsulaMickey.SetActive(false);
        RotacionPuzzle.SetActive(false);

      // EsferaRB.constraints = RigidbodyConstraints.FreezeAll;

        puzzleRotate.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        RayClick();
    }

   

   public  void RayClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickey")))
            {

                Debug.Log("CaraMickey");

                statusPuzzle = estadosPuzzle.CaraMickey;
               
                CapsulaMickey.SetActive(true);

                

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
                puzzleRotate.SetActive(true);



                RotacionPuzzle.SetActive(true);
                Rotacion(direccion);
                Combinacion pista1 = GameObject.Find("unoPareja").GetComponent<Combinacion>();
                Combinacion2 pista2 = GameObject.Find("dosPareja").GetComponent<Combinacion2>();
                Combinacion3 pista3 = GameObject.Find("tresPareja").GetComponent<Combinacion3>();
                Combinacion4 pista4 = GameObject.Find("cuatroPareja").GetComponent<Combinacion4>();
                Debug.Log(pista1.isCorrect);
                Debug.Log(pista2.isCorrect);
                Debug.Log(pista3.isCorrect);
                Debug.Log(pista4.isCorrect);
                if (pista1.isCorrect && pista2.isCorrect  && pista3.isCorrect  && pista4.isCorrect )
                {
                    Debug.Log("Ganaste");
                    GANASTE.SetActive(true);
                }
                Debug.Log("CaraMickeyFeliz");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMickeyGrosero")))
            {
                statusPuzzle = estadosPuzzle.CaraMickeyGrosero;
                CapsulaRotacion.SetActive(true);
                
                Vector3 scalar = CapsulaRotacion.transform.localScale;

                for (int i = 0; i <4; i++)
                {
                    if (CapsulaRotacion.transform.position == waypoints2[currentPoint].position)
                    {
                        currentPoint = (currentPoint + 1) % waypoints2.Length;
                    }

                }
                CapsulaRotacion.transform.position = Vector3.MoveTowards(CapsulaRotacion.transform.position, waypoints2[currentPoint].position, speed * Time.deltaTime);
                CapsulaRotacion.transform.Rotate(30, 0, 0);
                scalar.x += 0.009f;
                scalar.y += 0.009f;
                scalar.z += 0.009f;
                CapsulaRotacion.transform.localScale = scalar;
                Debug.Log("CaraMickeyGrosero");
            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraDonald")))
            {
                statusPuzzle = estadosPuzzle.CaraDonald;
                GameObject esfera = GameObject.Find("EsferaDonald");
                Vector3 crecer = esfera.transform.localScale;

                crecer.x += 0.2f;
                crecer.y += 0.2f;
                crecer.z += 0.2f;
                esfera.transform.localScale = crecer;

                if(fire < Time.time)
                {
                    crecer.x -= 0.2f;
                    crecer.y -= 0.2f;
                    crecer.z -= 0.2f;
                    esfera.transform.localScale = crecer;
                    fire = Time.time + timeNext;
                }
                if(crecer.x>1 &&crecer.y >1 && crecer.z > 1)
                {
                    Debug.Log("Ganaste");
                    Destroy(esfera);
                    GANASTE.SetActive(true);
                }



            }

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CaraMariposa")))
            {
                //MiniJuegoEsfera();
                Debug.Log("CaraMariposa");
                
                GameObject nivel = GameObject.Find("nivel");
                nivel.SetActive(true);
                EsferaRB.useGravity = true;
            }

        }
    }

  
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
                CapsulaRotacion.SetActive(true);
               
            }
            if (statusPuzzle == estadosPuzzle.CaraMickeyFeliz)
            {
                RotacionPuzzle.SetActive(true);
                Combinacion pista1 = GameObject.Find("unoPareja").GetComponent<Combinacion>();
                Combinacion2 pista2 = GameObject.Find("dosPareja").GetComponent<Combinacion2>();
                Combinacion3 pista3 = GameObject.Find("tresPareja").GetComponent<Combinacion3>();
                Combinacion4 pista4 = GameObject.Find("cuatroPareja").GetComponent<Combinacion4>();
                RotacionPuzzle.SetActive(true);
                Rotacion(direccion);

                if (pista1.isCorrect && pista2.isCorrect && pista3.isCorrect && pista4.isCorrect)
                {
                    Debug.Log("GanastePistas");
                    GANASTE.SetActive(true);
                }
            }

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
           
           
            
            TitulosQR.SetActive(false);
            ImagenesDiferencias.SetActive(false);
            
            CapsulaMickey.SetActive(false);
           // EsferaRB.constraints = RigidbodyConstraints.FreezeAll;
            EsferaRB.useGravity = false;
            RotacionPuzzle.SetActive(false);
            puzzleRotate.SetActive(false);
            nivel.SetActive(false);
        }
        else
        {
           
            TitulosQR.SetActive(false);
            ImagenesDiferencias.SetActive(false);
            puzzleRotate.SetActive(false);
            
            CapsulaMickey.SetActive(false);
           
            EsferaRB.useGravity = false;
           
            RotacionPuzzle.SetActive(false);
        }
    }
}

