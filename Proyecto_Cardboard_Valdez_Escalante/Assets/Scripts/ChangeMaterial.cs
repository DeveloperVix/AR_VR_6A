using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material defaultMaterial, selected;
    private MeshRenderer meshrender;
    bool isRotating = false;


    float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        meshrender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating == true)
        {
            gameObject.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }

    public void ChangeColor()
    {
        meshrender.material = defaultMaterial;
    }

    public void ReturnColor()
    {
        meshrender.material = selected;
    }


    public void RotateCube()
    {
        isRotating = true;
    }

    public void NoRotate()
    {
        isRotating = false;
    }
}
