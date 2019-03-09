using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCube : MonoBehaviour
{
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
    public MeshRenderer meshCilindro;
    //public LayerMask layers;
    RaycastHit rayHit;//fisicas raycast(objetos que tengan un collider)
    Camera thisCamera;//variable para obtener este componente
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CubeRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("boton izquierdo");
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Capsula")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                for (int i = 0; i < puntos.Length; i++)
                {
                    if (capsula.transform.position == puntos[currentPoint].position)//si la posicion inicial es igual al waypoint(basicamente es para asegurarse de que esta pasando por el punto
                    {
                        currentPoint = (currentPoint + 1) % puntos.Length;
                    }
                }
                capsula.transform.position = Vector3.MoveTowards(capsula.transform.position, puntos[currentPoint].position, speed * Time.deltaTime);//Transform.position = el punto incial, siguientepunto = a donde quiero que te muevas, speed * Time.deltaTime = la velocidad a la que quiero que lo hagas
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Cubo")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                GameObject cubo = GameObject.Find("CubeScale");
                Vector3 escala = cubo.transform.localScale;
                escala.x += 0.1f;
                escala.y += 0.1f;
                escala.z += 0.1f;
                cubo.transform.localScale = escala;
            }

            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("Esfera")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                
                GameObject esfera = GameObject.Find("Sphere");
                Rigidbody rb = esfera.GetComponent<Rigidbody>();
                rb.useGravity = true;
            }
            //if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("CuboRotate")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            //{
                
            //}
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {

            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, LayerMask.GetMask("")))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {

            }
        }
    }

    void CubeRotation()
    {
        GameObject cubo = GameObject.Find("CubeRotate");
        Transform rotacion = cubo.GetComponent<Transform>();
        if (rotacion.localRotation.x >= 8 && rotacion.localRotation.x < 15 
            /*&& rotacion.localRotation.y <= -60 && rotacion.localRotation.y > -75*/
            && rotacion.localRotation.z >= 30 && rotacion.localRotation.z < 45)
        {
            Debug.LogError("Puzzle completado");
        }
    }
    public void Mas()
    {
        GameObject cubo = GameObject.Find("CubeRotate");

        rotD += 30;
        cubo.transform.Rotate(0, rotD * Time.deltaTime , 0);
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
