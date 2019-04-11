using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    MeshRenderer mesRender;
    public Material[] mMatelia;
    public bool rota = false;
    public float vely = 50f;
    // Start is called before the first frame update
    void Start()
    {
        mesRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rota==true) {
            gameObject.transform.Rotate(new Vector3(0f, vely, 0f) * Time.deltaTime);
        }
        
    }
    public void entra() {
        mesRender.material = mMatelia[1];
    }
    public void sal() {
        mesRender.material = mMatelia[0];
    }
    public void entraR()
    {
        rota = true;
    }
    public void salR()
    {
        rota = false;
    }
}
