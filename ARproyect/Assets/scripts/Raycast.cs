using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField]
    public Camera thisCamera;
    public Animator Anim;
    public Animator Anim2;
    public Animator Anim3;
    public Puzzles puzzle;
    public Puzzles puzzle2;
    public Puzzles puzzle3;
    public LayerMask chucha;
    public LayerMask chucha2;
    public LayerMask chucha3;
    public LayerMask chucha4;
    public LayerMask chucha5;
    public LayerMask chucha6;

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
                Debug.Log("Tocaste el objeto 3 xd");
            }
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, chucha6))
            {
                //puzzle.Escala1();
                Anim3.SetBool("DOS", true);
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
    }



    
}
