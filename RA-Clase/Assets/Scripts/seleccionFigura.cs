using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionFigura : MonoBehaviour
{
    [SerializeField]
    protected Material defaultMaterial, selected;

    private MeshRenderer meshRenderer;

    public bool estaSeleccionada = false;

    GameObject thisCamera;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        thisCamera = GameObject.Find("ARCamera");
    }

    public void Seleccionado()
    {
        if (!estaSeleccionada)
        {
            meshRenderer.material = defaultMaterial;
        }
        else
        {
            meshRenderer.material = selected;
        }
    }
}
