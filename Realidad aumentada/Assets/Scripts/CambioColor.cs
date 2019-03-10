using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColor : MonoBehaviour
{
    [SerializeField]//muestra las variables dentro del inspector
    protected Material defaultMaterial, selected;//creamos dos materiales, si esta seleccionado se pone el material seleccionado, si no se queda con su material por default
    //public GameObject obj;
    private MeshRenderer m;
    public bool isSelected;//variable que nos ayuda a detectar si esta seleccionada la unidad
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<MeshRenderer>();

        Selected();
    }
    public void Selected()//metodo que nos hace toda la funcion de detectar la seleccion
    {
        if (!isSelected)
        {
            m.material = defaultMaterial;
        }
        else
        {
            m.material = selected;
        }
    }
}
