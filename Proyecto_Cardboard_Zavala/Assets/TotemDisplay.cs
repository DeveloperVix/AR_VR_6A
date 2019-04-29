using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemDisplay : MonoBehaviour
{
    /*Material Material1, Material2;*/

    public bool rotating = false;
    public CubeScript totem;
    private MeshRenderer MeshRender;
    public Material Material1, Material2;
    float speed = 250;

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(totem.text);
        MeshRender = GetComponent<MeshRenderer>();
        /*totem.looking();
        totem.nolooking();
        totem.ChangeMaterial();
        totem.DefaultMaterial();*/
        
    }

    void Update()
    {
        if (rotating)
        {
            gameObject.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }

    public void looking()
    {
        rotating = true;
    }

    public void nolooking()
    {
        rotating = false;
    }

    public void ChangeMaterial()
    {
        MeshRender.material = Material1;
    }

    public void DefaultMaterial()
    {
        MeshRender.material = Material2;
    }

}
