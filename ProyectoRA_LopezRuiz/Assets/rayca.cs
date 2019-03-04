using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class rayca : MonoBehaviour {

    public float raylength;
    public LayerMask layermask, layermask1, layermask2, layermask3;
    bool ama = true, verd = true, azu= true, rojo= true;
    public Material color_actual;

    public TextMeshProUGUI texto_puzzles;
	void Start ()
    {
        color_actual.color = Color.yellow;
        ama = true; verd = false; azu = false; rojo = false;
    }
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit, raylength, layermask))
            {
                if (hit.collider.name == "amarillo" && ama == true)
                {
                    Debug.Log("lol si entra solo al cubo");
                    color_actual.color = Color.red;
                    ama = false; verd = false; azu = false; rojo = true;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask1))
            {
                if (hit.collider.name == "rojo" && rojo == true)
                {
                    Debug.Log("rojo");
                    color_actual.color = Color.blue;
                    ama = false; verd = false; azu = true; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask2))
            {
                if (hit.collider.name == "azul" && azu == true)
                {
                    Debug.Log("azul");
                    color_actual.color = Color.green;
                    ama = false; verd = true; azu = false; rojo = false;
                }
            }
            if (Physics.Raycast(ray, out hit, raylength, layermask3))
            {
                if (hit.collider.name == "verde" && verd == true)
                {
                    Debug.Log("verde");
                    color_actual.color = Color.white;
                    verd = false;
                    texto_puzzles.text = "puzzles 1";
                }
            }
        }
	}
}
