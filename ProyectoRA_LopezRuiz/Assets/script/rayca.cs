using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class rayca : MonoBehaviour
{



    //puzzle colores
    bool ama = true, verd = true, azu = true, rojo = true;
    public Material color_actual;
    //puzzle colores



    //puzzle triangulo
    int speed = 0;
    Coroutine speedCo;
    public Animator triangulo_anim;
    public Transform target;
    bool boolwin = false;
    //puzzle triangulo




    //puzzle del panel
    public Animator animacion_panel;
    bool visto = false;
    public Material material_1, material_2, material_3;
    int contador_1, contador_2, contador_3;
    bool raycast_desactivado = false;
    //puzzle del panel



    //puzzle choque de cubos
    public Animator animacion_cubo_chocar;
    public trigger scrip_trigger;
    bool gano = false;
    public Material material_cubo;
    //puzzle choque de cubos



    //puzzle de desaparecer cosas
    public GameObject cyl1g, cyl2g, cyl3g, cyl4g;
    public int cont_objetos;
    bool empezo_el_conteo = true;
    //puzzle de desaparecer cosas



    //cubo rapido puzzle
    public GameObject cubo_rapido_go;
    //cubo rapido puzzle


    //general
    public TextMeshProUGUI texto_puzzles;
    int puzzles_superados;
    public GameObject panel_win;
    public LayerMask amarillo, rojos, azul, verde, triangulo, panel, esfera1, esfera2, esfera3, chocar, cyl1, cyl2, cyl3, cyl4, cubo_fast;
    public float raylength;
    //general


    void Start()
    {
        material_1.color = Color.white; material_2.color = Color.white; material_3.color = Color.white;
        color_actual.color = Color.yellow;
        ama = true; verd = false; azu = false; rojo = false;
        material_cubo.color = Color.red;
    }


    void Update()
    {
        raycast_funcion();
        puzzle_triangulo();
        checar_trigger_y_win();
    }


    public void raycast_funcion()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //cuadrados de colores
            if (Physics.Raycast(ray, out hit, raylength, amarillo))
            {
                if (ama == true)
                {
                    Debug.Log("lol si entra solo al cubo");
                    color_actual.color = Color.red;
                    ama = false; verd = false; azu = false; rojo = true;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, rojos))
            {
                if (rojo == true)
                {
                    Debug.Log("rojo");
                    color_actual.color = Color.blue;
                    ama = false; verd = false; azu = true; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, azul))
            {
                if (azu == true)
                {
                    Debug.Log("azul");
                    color_actual.color = Color.green;
                    ama = false; verd = true; azu = false; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, verde))
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
            if (Physics.Raycast(ray, out hit, raylength, triangulo))
            {
                speed += 2;
                if (speedCo == null)
                {
                    print("Entre jeje");
                    speedCo = StartCoroutine("ralientizar");
                }
                if (speed > 30 && boolwin == false)
                {
                    triangulo_anim.SetBool("vuela", true);
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;
                    boolwin = true;
                }
            }



            //panel escalado
            if (Physics.Raycast(ray, out hit, raylength, panel))
            {
                if (visto == false)
                {
                    //Debug.Log("ewequepedo");
                    animacion_panel.SetBool("lol", true);
                    visto = true;
                }
                else
                {
                    animacion_panel.SetBool("lol", false);
                    visto = false;
                }
            }


            if (Physics.Raycast(ray, out hit, raylength, esfera1) && raycast_desactivado == false)
            {

                contador_1++;

                if (contador_3 == 1 && contador_1 == 2 && contador_2 == 3)
                {
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;
                    raycast_desactivado = true;
                }

                if (contador_1 > 3)
                {
                    contador_1 = 1;
                }

                if (contador_1 == 1)
                {
                    material_1.color = Color.red;
                }
                if (contador_1 == 2)
                {
                    material_1.color = Color.green;
                }
                if (contador_1 == 3)
                {
                    material_1.color = Color.yellow;
                }
                Debug.Log("prueba1");
            }
            if (Physics.Raycast(ray, out hit, raylength, esfera2) && raycast_desactivado == false)
            {

                contador_2++;

                if (contador_3 == 1 && contador_1 == 2 && contador_2 == 3)
                {
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;
                    raycast_desactivado = true;
                }


                if (contador_2 > 3)
                {
                    contador_2 = 1;
                }


                if (contador_2 == 1)
                {
                    material_2.color = Color.red;
                }
                if (contador_2 == 2)
                {
                    material_2.color = Color.green;
                }
                if (contador_2 == 3)
                {
                    material_2.color = Color.yellow;
                }
                Debug.Log("prueba2");
            }
            if (Physics.Raycast(ray, out hit, raylength, esfera3) && raycast_desactivado == false)
            {

                contador_3++;

                if (contador_3 == 1 && contador_1 == 2 && contador_2 == 3)
                {
                    puzzles_superados += 1;
                    texto_puzzles.text = "puzzles " + puzzles_superados;
                    raycast_desactivado = true;
                }


                if (contador_3 > 3)
                {
                    contador_3 = 1;
                }
                if (contador_3 == 1)
                {
                    material_3.color = Color.red;
                }
                if (contador_3 == 2)
                {
                    material_3.color = Color.green;
                }
                if (contador_3 == 3)
                {
                    material_3.color = Color.yellow;
                }
                Debug.Log("prueba3");

            }


            if (Physics.Raycast(ray, out hit, raylength, chocar) && scrip_trigger.puede_moverse == true)
            {
                animacion_cubo_chocar.SetTrigger("muevete");
            }


            //desaparecer objetos
            if (Physics.Raycast(ray, out hit, raylength, cyl1))
            {
                cyl1g.SetActive(false);
                cont_objetos++;
                if (empezo_el_conteo == true)
                {
                    StartCoroutine("reaparecer");
                }
                
            }
            if (Physics.Raycast(ray, out hit, raylength, cyl2))
            {
                cyl2g.SetActive(false);
                cont_objetos++;
                if (empezo_el_conteo == true)
                {
                    StartCoroutine("reaparecer");
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, cyl3))
            {
                cyl3g.SetActive(false);
                cont_objetos++;
                if (empezo_el_conteo == true)
                {
                    StartCoroutine("reaparecer");
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, cyl4))
            {
                cyl4g.SetActive(false);
                cont_objetos++;
                if (empezo_el_conteo == true)
                {
                    StartCoroutine("reaparecer");
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, cubo_fast))
            {
                puzzles_superados += 1;
                texto_puzzles.text = "puzzles " + puzzles_superados;
                cubo_rapido_go.SetActive(false);
            }
        }
    }


    public void puzzle_triangulo()
    {
        target.transform.Rotate(0, 0, speed);
    }

    public void checar_trigger_y_win()
    {
        if (scrip_trigger.toco == true && gano == false)
        {
            puzzles_superados += 1;
            texto_puzzles.text = "puzzles " + puzzles_superados;
            material_cubo.color = Color.green;
            gano = true;
        }
        if (puzzles_superados == 6)
        {
            panel_win.SetActive(true);
        }
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

    IEnumerator reaparecer()
    {
        empezo_el_conteo = false;

            yield return new WaitForSeconds(3f);
        if (cont_objetos > 3)
        {
            puzzles_superados += 1;
            texto_puzzles.text = "puzzles " + puzzles_superados;
        }
        else
        {
            cyl1g.SetActive(true);
            cyl2g.SetActive(true);
            cyl3g.SetActive(true);
            cyl4g.SetActive(true);
            cont_objetos = 0;
            empezo_el_conteo = true;
        }
    }
}
//comit del domingo (puzzle_final) y el de hoy ejercicio puzzle