using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUEGO_PUZZLE : MonoBehaviour
{
    public int contador;

    public Text puntuacion;

    string btname;
    public GameObject objectRotate;
    public GameObject objectscalate;

    public float rotateSpeed = 50f;
    bool rotateStatus = false;

    bool escalarstatus = false;

    private Vector3 mOffset;

    private float mZCoord;

    public GameObject panel;

    void Start()
    {
        
        //ContentScaleManager.ContentScaleChangedEvent += ContentScaleChanged;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (rotateStatus == true)
        {
            objectRotate.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }

        if (escalarstatus == true)
        {
            objectscalate.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            objectscalate.transform.localScale += new Vector3(1f, 1f, 1f);
        }

        if (Input.GetMouseButtonDown(0) )
        {

            if (contador == 10)
            {
                panel.SetActive(true);
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,9))
            {
                
                btname = hit.transform.name;
                switch (btname)
                {
                    case "Casco":

                       otrascena();
                        // Destroy(hit.collider.gameObject);

                        break;
                    case "circulo":
                        Destroy(hit.collider.gameObject);
                        contador++;
                        Debug.Log("Puntaje");
                        Debug.Log(contador);
                        puntuacion.text = "Puntuacion : " + contador;
                        break;

                    case "rotar":
                        Rotasi();
                        break;

                    case "mover":
                        OnMouseDown();
                        break;

                    case "escalar":
                        escalasi();
                        break;

                }
            }
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)&&tag=="CASCO")
            {
               
                    Destroy(gameObject);
                
            }
        }*/
    }

   

    public void otrascena()
    {
        SceneManager.LoadScene(2);
    }
    public void Rotasi()
    {

        if (rotateStatus == false)
        {
            rotateStatus = true;
        }
        else
        {
            rotateStatus = false;
        }
    }

    public void escalasi()
    {

        if (escalarstatus == false)
        {
            escalarstatus = true;
        }
        else
        {
            escalarstatus = false;
        }
    }

    //mover 

    public void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }


    public void Awake()
    {
        contador = 0;
        //puntuacion.text = "Puntuacion" + contador;
    }

   
}
