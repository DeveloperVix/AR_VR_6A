using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemDisplay : MonoBehaviour
{
    public Material Material1, Material2;
    private MeshRenderer MeshRender;

    public CubeScript Totem;
    public bool rotating = false;
    float speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Totem.text);
        MeshRender = GetComponent<MeshRenderer>();
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
