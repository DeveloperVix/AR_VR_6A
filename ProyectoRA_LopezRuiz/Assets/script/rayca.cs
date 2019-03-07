using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class rayca : MonoBehaviour {
    //puzzle colores
    public float raylength;
    public LayerMask layermask, layermask1, layermask2, layermask3, layermask4;
    bool ama = true, verd = true, azu= true, rojo= true;
    public Material color_actual;
    //puzzle colores



    //puzzle triangulo
    int speed = 0;
    Coroutine speedCo;
    public Animator triangulo_anim;
    public Transform target;
    //puzzle triangulo



    //general
    public TextMeshProUGUI texto_puzzles;
    int puzzles_superados;
    //general
    

	void Start ()
    {
        color_actual.color = Color.yellow;
        ama = true; verd = false; azu = false; rojo = false;
    }
	
	
	void Update ()
    {
        raycast_funcion();
        puzzle_triangulo();
    }


    public void raycast_funcion()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //cuadrados de colores
            if (Physics.Raycast(ray, out hit, raylength, layermask))
            {
                if (ama == true)
                {
                    Debug.Log("lol si entra solo al cubo");
                    color_actual.color = Color.red;
                    ama = false; verd = false; azu = false; rojo = true;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask1))
            {
                if (rojo == true)
                {
                    Debug.Log("rojo");
                    color_actual.color = Color.blue;
                    ama = false; verd = false; azu = true; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask2))
            {
                if (azu == true)
                {
                    Debug.Log("azul");
                    color_actual.color = Color.green;
                    ama = false; verd = true; azu = false; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask3))
            {
                if (verd == true)
                {
                    Debug.Log("verde");
                    color_actual.color = Color.white;
                    verd = false;
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;

                }
            }

            //triangulo
            if (Physics.Raycast(ray, out hit, raylength, layermask4))
            {
                speed += 2;
                if (speedCo == null)
                {
                    print("Entre jeje");
                    speedCo = StartCoroutine("ralientizar");
                }
                if (speed > 30)
                {
                    triangulo_anim.SetBool("vuela",true);
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;
                }
            }
        }
    }

    
    public void puzzle_triangulo()
    {
        target.transform.Rotate(0, 0, speed);
    }
    

    IEnumerator ralientizar()
    {
        bool hazlo = true;
        while (hazlo)
        {
            yield return new WaitForSeconds(0.5f);
            speed -= 1;
            if (speed <= 0)
            {
                speed = 0;
                hazlo = false;
            }
        }
        speedCo = null;
    }
}
//comit del domingo (puzzle_final) y el de hoy ejercicio puzzle