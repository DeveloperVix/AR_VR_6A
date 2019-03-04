using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]
    protected Material defaultMaterial, selected;
    private MeshRenderer meshRenderer;
    public bool isSelected = false;
    protected Animator anim;
    GameObject thisCamera;

    void Start()
    {
        anim = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        //thisCamera = GameObject.Find("Main Camera");
        thisCamera = GameObject.Find("AR Camera");
        thisCamera.GetComponent<Seleccion>().unitsToSelect.Add(this.gameObject);
        dateSelected();
    }

    public void dateSelected()
    {
        if (!isSelected)
        {
            //anim.speed("movimiento1")=0;
            //meshRenderer.material = defaultMaterial;
        }
        else
        {
            anim.SetBool("movimiento1",true);
            //anim.play("movimiento1");
            // meshRenderer.material = selected;
        }

    }
}