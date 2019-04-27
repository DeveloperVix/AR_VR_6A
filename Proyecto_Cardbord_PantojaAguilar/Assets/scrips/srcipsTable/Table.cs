using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Table : ScriptableObject
{
    public bool[] estado;

    MeshRenderer mesRender;
    public Material[] mMatelia;
    public bool rota = false;
    public float vely = 50f;
    string res;
    public GameObject texto;
    public GameObject particulas;
    public GameObject sonido;

    public void EntrasT() {
        if (estado[0] == true)
        {
            mesRender.material = mMatelia[1];
        }
        if (estado[1] == true)
        {
            rota = true;
        }
        if (estado[2] == true)
        {
            texto.SetActive(true);
        }
        if (estado[3] == true)
        {
            sonido.SetActive(true);
        }
        if (estado[4] == true)
        {
            particulas.SetActive(true);
        }
    }
    public void SalT()
    {
        if (estado[0] == true)
        {
            mesRender.material = mMatelia[0];
        }
        if (estado[1] == true)
        {
            rota = false;
        }
        if (estado[2] == true)
        {
            texto.SetActive(false);
        }
        if (estado[3] == true)
        {
            sonido.SetActive(false);
        }
        if (estado[4] == true)
        {
            particulas.SetActive(false);
        }
    }
}
