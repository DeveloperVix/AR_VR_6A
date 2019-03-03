using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public Material defaultMaterial, selectedMaterial;//Crea dos variables del tipo Material 
    private MeshRenderer meshRenderer;
    public Animator anim;
    public bool isSelected = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();//obtener material 
        anim = GetComponent<Animator>();
        Selected();
    }

    public void Selected()
    {
        if (!isSelected)//preguntar si la unidad esta seleccionada
        {
            Debug.Log("Material Default");
            meshRenderer.material = defaultMaterial;//se metio el material a defaultMaterial
        }
        else
        {
            Debug.Log("Cambiando Material de selección");
            meshRenderer.material = selectedMaterial;//se metio el material a defaultMaterial
        }
    }
}
