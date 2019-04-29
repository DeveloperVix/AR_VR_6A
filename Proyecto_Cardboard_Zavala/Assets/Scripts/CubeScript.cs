using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]
public class CubeScript : ScriptableObject
{

    private MeshRenderer MeshRender;
    public bool rotating = false;
    public string text;
    public Material Material1, Material2;
    public ParticleSystem particles;
    public int rotationX;
    GameObject Tortem;
    float speed = 250;

    void Start()
    {
        
    }

    /*void Update()
    {
        if (rotating)
        {
            gameObject.transform.Rotate(Vector3.forward, speed*rotationX * Time.deltaTime);
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
    }*/

}


