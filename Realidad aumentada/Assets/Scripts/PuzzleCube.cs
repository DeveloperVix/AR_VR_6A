using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PuzzleCube : MonoBehaviour, ITrackableEventHandler
{
    //protected CambioColor cilindro;
    //MeshRenderer m;

    bool puzzle1 = false;
    bool puzzle2 = false;
    bool puzzle3 = false;
    bool puzzle4 = false;
    bool puzzle5 = false;
    bool puzzle6 = false;


    GameObject esfera;

    public GameObject particle;
    float timeRate = 0.5f;
    float nextFire;
    Rigidbody rb;
    GameObject botonesRot;
    GameObject videoFinal;
    GameObject mensajePuzzleComplete;
    GameObject mensajePuzzleComplete2;
    float rotD = 0f;//rotacion de derecha a izquierda
    float rotI = 0f;//rotacion de izquierda a derecha
    float rotA = 0f;//rotacion de arriba hacia abajo
    float rotB = 0f;//rotacion de abajo hacia arriba
    public float speed;//la velocidad a la que se movera el enemigo
    Vector3 siguientepunto;//punto actual al que se tiene que dirigir un enemigo
    public Transform[] puntos = new Transform[4];//hacemos el arreglo de los waypoints
    //public GameObject[] cilindros = new GameObject[29];
    public GameObject capsula;
    int currentPoint;
    //public LayerMask layers;
    RaycastHit rayHit;//fisicas raycast(objetos que tengan un collider)
    Camera thisCamera;//variable para obtener este componente

    protected TrackableBehaviour mTrackableBehaviour;
    public TrackableBehaviour cubeTarjet;

    enum estadoPuzzle { Null,Toad, Zorro, Control, Afro, Caracol, Perro, }
    estadoPuzzle stPuzzle = estadoPuzzle.Null;
    
    // Start is called before the first frame update
    void Start()
    {

        esfera = GameObject.Find("Sphere");
        rb = esfera.GetComponent<Rigidbody>();
        rb.useGravity = false;

        videoFinal = GameObject.Find("VideoFinal");
        videoFinal.SetActive(false);

        botonesRot = GameObject.Find("BotonesRot");//botones que rotaran el cubo
        mensajePuzzleComplete = GameObject.Find("PuzzleCompletado1");
        mTrackableBehaviour = cubeTarjet;
        mensajePuzzleComplete2 = GameObject.Find("PuzzleCompletado2");
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        botonesRot.SetActive(false);
        mensajePuzzleComplete.SetActive(false);
        mensajePuzzleComplete2.SetActive(false);

        thisCamera = GetComponent<Camera>();


        //m = cilindro.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CuboFinalizado();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Capsula")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                if (capsula.transform.position.y > 0.22 && capsula.transform.position.y < 0.30)
                {
                    Debug.LogWarning("puzzle1");
                    MeshRenderer meshRend = capsula.GetComponent<MeshRenderer>();
                    meshRend.material.color = Color.cyan;
                    puzzle1 = true;
                }
                stPuzzle = estadoPuzzle.Toad;
                for (int i = 0; i < puntos.Length; i++)
                {
                    if (capsula.transform.position == puntos[currentPoint].position)//si la posicion inicial es igual al waypoint(basicamente es para asegurarse de que esta pasando por el punto
                    {
                        currentPoint = (currentPoint + 1) % puntos.Length;
                    }
                }
                capsula.transform.position = Vector3.MoveTowards(capsula.transform.position, puntos[currentPoint].position, speed * Time.deltaTime);//Transform.position = el punto incial, siguientepunto = a donde quiero que te muevas, speed * Time.deltaTime = la velocidad a la que quiero que lo hagas
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Cubo")))//bugg puzzle2
            {
                stPuzzle = estadoPuzzle.Zorro;
                GameObject cubo = GameObject.Find("CubeScale");
                MeshRenderer mesh = cubo.GetComponent<MeshRenderer>();
                Vector3 escala = cubo.transform.localScale;

                if (escala.x < 0.57 && escala.y < 0.57 && escala.z < 0.57)
                {
                    escala.x += 0.1f;
                    escala.y += 0.1f;
                    escala.z += 0.1f;
                    cubo.transform.localScale = escala;
                }


                if (escala.x > 0.56 && escala.y > 0.56 && escala.z > 0.56)
                {
                    Debug.LogWarning("Puzzle2");
                    mesh.material.color = Color.cyan;
                    puzzle2 = true;
                }
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Esfera")))
            {
                stPuzzle = estadoPuzzle.Caracol;
                rb.useGravity = true;
                EsferaCol component = rayHit.collider.GetComponent<EsferaCol>();

                //if (component.finish)
                //{
                //    component.finish = false;
                Debug.LogWarning("Puzzle3");
                puzzle3 = true;
                //}
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CuboRotate")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                //mensajePuzzleComplete.SetActive(false);
                Debug.LogError("rotarrr");
                stPuzzle = estadoPuzzle.Afro;
                botonesRot.SetActive(true);
                GameObject cubo = GameObject.Find("CubeRotate");
                Transform rotacion = cubo.GetComponent<Transform>();
                MeshRenderer mesh = rotacion.GetComponent<MeshRenderer>();
                if (rotacion.localEulerAngles.x > 8 && rotacion.localEulerAngles.x < 15
                     /*&& rotacion.localEulerAngles.y > -70 && rotacion.localEulerAngles.y < -60*/
                     && rotacion.localEulerAngles.z > 35 && rotacion.localEulerAngles.z < 42)
                {
                    Debug.LogWarning("Puzzle4");
                    puzzle4 = true;
                    mesh.material.color = Color.cyan;
                    //mensajePuzzleComplete2.SetActive(true);
                }
            }
            
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Cilindro")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                stPuzzle = estadoPuzzle.Control;
                CambioColor cilindro = rayHit.collider.GetComponent<CambioColor>();
                if (!cilindro.isSelected)//si no es verdadero
                {
                    cilindro.isSelected = true;//ha sido seleccionado
                    cilindro.Selected();
                }
                else
                {
                    cilindro.isSelected = false;//no esta seleccionada
                    cilindro.Selected();
                }
                CambioColor control = GameObject.Find("Cylinder").GetComponent<CambioColor>();
                CambioColor control2 = GameObject.Find("Cylinder (4)").GetComponent<CambioColor>();
                CambioColor control3 = GameObject.Find("Cylinder (6)").GetComponent<CambioColor>();
                CambioColor control4 = GameObject.Find("Cylinder (1)").GetComponent<CambioColor>();
                CambioColor control5 = GameObject.Find("Cylinder (2)").GetComponent<CambioColor>();
                CambioColor control6 = GameObject.Find("Cylinder (3)").GetComponent<CambioColor>();
                CambioColor control7 = GameObject.Find("Cylinder (5)").GetComponent<CambioColor>();
                CambioColor control8 = GameObject.Find("Cylinder (7)").GetComponent<CambioColor>();
                CambioColor control9 = GameObject.Find("Cylinder (8)").GetComponent<CambioColor>();

                GameObject cubo = GameObject.Find("Cylinder");
                MeshRenderer mesh = cubo.GetComponent<MeshRenderer>();
                GameObject cubo2 = GameObject.Find("Cylinder (4)");
                MeshRenderer mesh2 = cubo2.GetComponent<MeshRenderer>();
                GameObject cubo3 = GameObject.Find("Cylinder (6)");
                MeshRenderer mesh3 = cubo3.GetComponent<MeshRenderer>();
                if (control.isSelected && control2.isSelected && control3.isSelected 
                    && !control4.isSelected && !control5.isSelected && !control6.isSelected
                    && !control7.isSelected && !control8.isSelected && !control9.isSelected)
                {
                    Debug.LogWarning("Puzzle5");
                    puzzle5 = true;
                    mesh.material.color = Color.cyan;
                    mesh2.material.color = Color.cyan;
                    mesh3.material.color = Color.cyan;
                }
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("EsferaExplosion")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                stPuzzle = estadoPuzzle.Perro;
                GameObject cubo = GameObject.Find("SphereExplosion");
                Vector3 escala = cubo.transform.localScale;
                escala.x += 0.1f;
                escala.y += 0.1f;
                escala.z += 0.1f;
                cubo.transform.localScale = escala;

                if (nextFire < Time.time)
                {
                    escala.x -= 0.3f;
                    escala.y -= 0.3f;
                    escala.z -= 0.3f;
                    cubo.transform.localScale = escala;
                    nextFire = Time.time + timeRate;
                }

                if (escala.x > 1 && escala.y > 1 && escala.z > 1)
                {
                    Debug.LogWarning("Puzzle6");
                    puzzle6 = true;
                    Instantiate(particle, cubo.transform.position, Quaternion.identity);
                    Destroy(cubo);
                }
            }
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (stPuzzle == estadoPuzzle.Toad)
            {
                //GameObject cilindro = GameObject.Find("Capsule");
                //Debug.Log("entro toad");
                //Debug.LogError(capsula.transform.position.y);
                //if(capsula.transform.position.y > 0.22 && capsula.transform.position.y < 0.30)
                //{
                //    Debug.Log("Posicion toad");
                //    MeshRenderer meshRend = cilindro.GetComponent<MeshRenderer>();
                //    meshRend.material.color = Color.cyan;
                //}
            }
            if (stPuzzle == estadoPuzzle.Control)//bugg puzzle5
            {
                botonesRot.SetActive(false);
                //mensajePuzzleComplete2.SetActive(false);
                CambioColor control = GameObject.Find("Cylinder").GetComponent<CambioColor>();
                CambioColor control2 = GameObject.Find("Cylinder (4)").GetComponent<CambioColor>();
                CambioColor control3 = GameObject.Find("Cylinder (6)").GetComponent<CambioColor>();
                GameObject cubo = GameObject.Find("Cylinder");
                MeshRenderer mesh = cubo.GetComponent<MeshRenderer>();
                GameObject cubo2 = GameObject.Find("Cylinder (4)");
                MeshRenderer mesh2 = cubo2.GetComponent<MeshRenderer>();
                GameObject cubo3 = GameObject.Find("Cylinder (6)");
                MeshRenderer mesh3 = cubo3.GetComponent<MeshRenderer>();
                if (control.isSelected && control2.isSelected && control3.isSelected)
                {
                    Debug.LogWarning("Puzzle5");
                    puzzle5 = true;
                    mesh.material.color = Color.cyan;
                    mesh2.material.color = Color.cyan;
                    mesh3.material.color = Color.cyan;
                    //mensajePuzzleComplete.SetActive(true);
                }
            }
            if (stPuzzle == estadoPuzzle.Afro)//bug puzzke4
            {
                botonesRot.SetActive(true);
                //mensajePuzzleComplete.SetActive(false);
                GameObject cubo = GameObject.Find("CubeRotate");
                Transform rotacion = cubo.GetComponent<Transform>();
                MeshRenderer mesh = rotacion.GetComponent<MeshRenderer>();
                if (rotacion.localEulerAngles.x > 8 && rotacion.localEulerAngles.x < 15
                     /*&& rotacion.localEulerAngles.y > -70 && rotacion.localEulerAngles.y < -60*/
                     && rotacion.localEulerAngles.z > 35 && rotacion.localEulerAngles.z < 42)
                {
                    Debug.LogWarning("Puzzle4");
                    puzzle4 = true;
                    mesh.material.color = Color.cyan;
                    //mensajePuzzleComplete2.SetActive(true);
                }
            }
            if (stPuzzle == estadoPuzzle.Caracol)
            {
                rb.useGravity = true;
            }
            if (stPuzzle == estadoPuzzle.Perro)
            {
                Debug.Log("perroooo");
                //GameObject cubo = GameObject.Find("SphereExplosion");
                //Vector3 escala = cubo.transform.localScale;
                
            }
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {

            rb.useGravity = false;
            botonesRot.SetActive(false);
            //mensajePuzzleComplete.SetActive(false);
            //mensajePuzzleComplete2.SetActive(false);
        }
    }

    void CuboFinalizado()
    {
        if (puzzle1 && puzzle2 && puzzle3 && puzzle4 && puzzle5 && puzzle6)
        {
            videoFinal.SetActive(true);
        }
    }

    public void Mas()
    {
        GameObject cubo = GameObject.Find("CubeRotate");
        Transform rotacion = cubo.GetComponent<Transform>();
        MeshRenderer mesh = rotacion.GetComponent<MeshRenderer>();

        rotD += 30;
        cubo.transform.Rotate(0, rotD * Time.deltaTime , 0);
        if (rotacion.localEulerAngles.x > 8 && rotacion.localEulerAngles.x < 15
                    /*&& rotacion.localEulerAngles.y > -70 && rotacion.localEulerAngles.y < -60*/
                    && rotacion.localEulerAngles.z > 35 && rotacion.localEulerAngles.z < 42)
        {
            mesh.material.color = Color.cyan;
            //mensajePuzzleComplete2.SetActive(true);
        }
    }
    public void Menos()
    {
        GameObject cubo = GameObject.Find("CubeRotate");

        rotI-= 30;
        cubo.transform.Rotate(0, rotI * Time.deltaTime, 0);
    }
    public void Arriba()
    {
        GameObject cubo = GameObject.Find("CubeRotate");

        rotA += 30;
        cubo.transform.Rotate(rotA * Time.deltaTime, 0, 0);
    }
    public void Abajo()
    {
        GameObject cubo = GameObject.Find("CubeRotate");

        rotB -= 30;
        cubo.transform.Rotate(rotB * Time.deltaTime, 0, 0);
    }
    public void DiagonalA()
    {
        GameObject cubo = GameObject.Find("CubeRotate");
        rotD += 30;
        rotA += 30;
        cubo.transform.Rotate(rotA * Time.deltaTime, rotD * Time.deltaTime, 0);
    }
    public void DiagonalB()
    {
        GameObject cubo = GameObject.Find("CubeRotate");
        rotI -= 30;
        rotB -= 30;
        cubo.transform.Rotate(rotB * Time.deltaTime, rotI * Time.deltaTime, 0);
    }
}
