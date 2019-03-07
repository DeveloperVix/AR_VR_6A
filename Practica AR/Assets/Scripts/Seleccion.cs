using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public Material[] colores;
    //public Material MaterialAzul, MaterialAmarillo, MaterialRosa, MaterialVerde, MaterialRojo;//Crea dos variables del tipo Material 
    public MeshRenderer meshRenderer;
    public Animator anim;
    public bool isSelected = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();//obtener material 
        anim = GetComponent<Animator>();
        ChangeColors();
    }

    public void ChangeColors()
    {
        #region if para seleccion
        /*if (!isSelected)//preguntar si la unidad esta seleccionada
        {
            Debug.Log("Material Default");
            meshRenderer.material = MaterialAzul;//se metio el material a defaultMaterial
        }
        else
        {
            Debug.Log("Cambiando Material de selección");
            meshRenderer.material = MaterialAmarillo;//se metio el material de selección
        }*/
        #endregion 
        StartCoroutine(CambioColor());
        
    }

    IEnumerator CambioColor()
    {
        int cont = 0;
        int maxCont = colores.Length;
        while (true)
        {
            Debug.Log("CAMBIANDO DE COLOR");
            meshRenderer.material = colores[cont];
            cont++;
            if (cont >= maxCont)
            {
                cont = 0;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
