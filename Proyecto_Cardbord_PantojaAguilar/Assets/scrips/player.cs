using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Table Aciones;

    MeshRenderer mesRender;
    public Material[] mMatelia;
    public bool rota = false;
    public float vely = 50f;
    string res;
    public GameObject texto;
    public GameObject particulas;
    public GameObject sonido;
    public bool[] estado;
    // Start is called before the first frame update
    void Start()
    {

        mesRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (res) {
            case "holo":
                break;
            case "holi":
                //gameObject.transform.Rotate(new Vector3(0f, vely, 0f) * Time.deltaTime);
                break;
        }
        if (rota==true) {
            gameObject.transform.Rotate(new Vector3(0f, vely, 0f) * Time.deltaTime);
          
        }
        
    }
    
    public void entra() {
        mesRender.material = mMatelia[1];
        res = "holo";
        //Debug.Log(res);
    }
    public void sal() {
        mesRender.material = mMatelia[0];
        res = "hola";
    }
    public void entraR()
    {
        rota = true;
        res = "holi";
    }
    public void salR()
    {
        rota = false;
        res = "hola";
    }
    public void entraTex()
    {
        /*var obj = GameObject.FindWithTag("Texto1");
        obj.SetActive(true);*/
        //GameObject.FindWithTag("Texto1").SetActive(true);
        texto.SetActive(true);
    }
    public void salTex()
    {
        texto.SetActive(false);
    }
    public void entraSon()
    {
        sonido.SetActive(true);
    }
    public void salSon()
    {
        sonido.SetActive(false);
    }
    public void entraPar()
    {
        particulas.SetActive(true);
    }
    public void salPar()
    {
        particulas.SetActive(false);
    }
   
    //Control de todos en uno solo
    //******************************************************************************************
    public void Eglobal() {
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
    public void Sglobal()
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
    //***********************************************************************************************
    }

}
