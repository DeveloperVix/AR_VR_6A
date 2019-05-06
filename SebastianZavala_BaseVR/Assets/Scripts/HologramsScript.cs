using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HologramsScript : MonoBehaviour
{
    public Material MaterialA, MaterialB;
    private MeshRenderer MeshRender;
    public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        MeshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaterial()
    {
        MeshRender.material = MaterialA;
        screen.SetActive(true);
    }

    public void DefaultMaterial()
    {
        MeshRender.material = MaterialB;
        screen.SetActive(false);
    }
}
