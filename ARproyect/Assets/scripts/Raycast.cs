using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField]
    public Camera thisCamera;
    public Animator Anim, Anim2, Anim3;
    public Puzzles puzzle, puzzle2, puzzle3, cubito1, cubito2, cubito3;
    public GameObject way1, way2, way3, win;
    public LayerMask chucha, chucha2, chucha3, chucha4, chucha5, chucha6;
    bool a1, a2, a3;

    //public GameObject cubito;
    //public GameObject Wayyy;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clic izq");
            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha))
            {
                puzzle.Movimiento();
                Debug.Log("Tocaste el objeto 1 xd");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha2))
            {
                puzzle2.Movimiento2();
                Debug.Log("Tocaste el objeto 2 xd");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha3))
            {
                //puzzle.Escala1();
                Anim.SetBool("salida", true);
                a1 = true;
                Debug.Log("Tocaste el objeto 3 xd"); 
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha4))
            {
                puzzle3.Movimiento3();
                Debug.Log("Tocaste el objeto 4 xd");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha5))
            {
                //puzzle.Escala1();
                Anim2.SetBool("Salida2", true);
                a2 = true;
                Debug.Log("Tocaste el objeto 3 xd");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha6))
            {
                //puzzle.Escala1();
                Anim3.SetBool("DOS", true);
                a3 = true;
                Debug.Log("Tocaste el objeto 3 xd");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit rayHit1;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit1, Mathf.Infinity, chucha3))
            {
                //puzzle.Escala1();
                Anim.SetBool("salida", false);
                Debug.Log("Tocaste la segunda");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit1, Mathf.Infinity, chucha5))
            {
                //puzzle.Escala1();
                Anim2.SetBool("Salida2", false);
                Debug.Log("Tocaste la segunda");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit1, Mathf.Infinity, chucha6))
            {
                //puzzle.Escala1();
                Anim3.SetBool("DOS", false);
                Debug.Log("Tocaste la segunda");
            }
        }
        Ganar();
    }

    public void Ganar()
    {
        if (cubito1.objetoxd.transform.position == way1.transform.position && cubito2.objetoxd.transform.position == way2.transform.position
            && cubito3.objetoxd.transform.position == way3.transform.position && a1 == true && a2 == true && a3 == true)
        {
            Debug.Log("completaste 3 puzzles, no los muevas mas xd");
            win.SetActive(true);
        }
    }




}
