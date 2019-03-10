using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public GameObject reglas;
    public Transform waypoint;
    public GameObject moverButton;
    Seleccion seleccionScript; 
    public GameObject ganar;
    Camera thisCamera;//variable tipo camara
    public GameObject capsula1;
    public GameObject capsula2;
    public GameObject capsula3;
    public GameObject capsula4;
    public GameObject capsula5;
    public GameObject capsula6;
    bool bandera = true;

    void Start()
    {
        thisCamera = GetComponent<Camera>();
        seleccionScript = GetComponent<Seleccion>();
        Reglas();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))//es clic izquierdo y 1 es para el derecho
        {
            Debug.Log("HICISTE CLIC IZQUIERDO");

            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))//donde de clic será donde se creara el rayo
            {
                Debug.Log("SELEECIONASTE UN OBJETO :v");
                Seleccion seleccion = rayHit.collider.GetComponent<Seleccion>();//se guarda el objeto en donde choco el rayo(donde dimos clic) 
                if (seleccion.changeColor == true)
                {
                    Debug.Log("Pausando animacion TOP");
                    seleccion.anim.speed = 0;
                    seleccion.changeColor = false;
                    while (capsula1.GetComponent<Seleccion>().ColorActual ==
                            capsula6.GetComponent<Seleccion>().ColorActual &&
                            capsula2.GetComponent<Seleccion>().ColorActual ==
                            capsula4.GetComponent<Seleccion>().ColorActual &&
                            capsula5.GetComponent<Seleccion>().ColorActual ==
                            capsula3.GetComponent<Seleccion>().ColorActual &&
                            bandera == true)
                    {
                        moverButton.SetActive(true);
                        bandera = false;
                    }
                    //seleccion.ColorActual = seleccion.cont;
                    //seleccion.Selected();
                }
                else
                {
                    seleccion.anim.speed = 1;
                    seleccion.changeColor = true;
                    seleccion.ChangeColors();
                    //seleccion.Selected();
                }
            }

            
        }
    }

    public void Mover()
    {
        Debug.Log("MOVIENDO CAPSULA UNO");
        capsula1.transform.position = Vector3.MoveTowards(capsula1.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        Debug.Log("MOVIENDO CAPSULA DOS");
        capsula2.transform.position = Vector3.MoveTowards(capsula2.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        Debug.Log("MOVIENDO CAPSULA TRES");
        capsula3.transform.position = Vector3.MoveTowards(capsula3.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        Debug.Log("MOVIENDO CAPSULA CUATRO");
        capsula4.transform.position = Vector3.MoveTowards(capsula4.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        Debug.Log("MOVIENDO CAPSULA CINCO");
        capsula5.transform.position = Vector3.MoveTowards(capsula5.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        Debug.Log("MOVIENDO CAPSULA SEIS");
        capsula6.transform.position = Vector3.MoveTowards(capsula6.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
        /*MoverCapsula1();
        MoverCapsula2();
        MoverCapsula3();
        MoverCapsula4();
        MoverCapsula5();
        MoverCapsula6();*/
    }

    public void Reglas()
    {
        StartCoroutine(reglasxdON());
    }

    public IEnumerator reglasxdON()
    {
        reglas.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(reglasxdOFF());
    }

    public IEnumerator reglasxdOFF()
    {
        yield return new WaitForSeconds(3f);
        reglas.SetActive(false);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("AR");
    }

    /*public void MoverCapsula1()
    {
        Debug.Log("MOVIENDO CAPSULA UNO");
        capsula1.transform.position = Vector3.MoveTowards(capsula1.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }

    public void MoverCapsula2()
    {
        Debug.Log("MOVIENDO CAPSULA DOS");
        capsula2.transform.position = Vector3.MoveTowards(capsula2.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }

    public void MoverCapsula3()
    {
        Debug.Log("MOVIENDO CAPSULA TRES");
        capsula3.transform.position = Vector3.MoveTowards(capsula3.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }

    public void MoverCapsula4()
    {
        Debug.Log("MOVIENDO CAPSULA CUATRO");
        capsula4.transform.position = Vector3.MoveTowards(capsula4.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }

    public void MoverCapsula5()
    {
        Debug.Log("MOVIENDO CAPSULA CINCO");
        capsula5.transform.position = Vector3.MoveTowards(capsula5.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }

    public void MoverCapsula6()
    {
        Debug.Log("MOVIENDO CAPSULA CINCO");
        capsula6.transform.position = Vector3.MoveTowards(capsula6.transform.position, waypoint.transform.position, 3.5f * Time.deltaTime);
    }*/
}
