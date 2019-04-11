using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INSERTARMATERIAL : MonoBehaviour
{
    public Material materialdefecto, selected;
    private MeshRenderer taco;
    public float rotateSpeed = 50f;
    bool rotateStatus = false;
    //public GameObject objectRotate;
    // Start is called before the first frame update
    void Start()
    {
        taco = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateStatus == true)
        {
            gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
    public void Changecolor()
    {
        taco.material = materialdefecto;
    }
    public void ReturnColor()
    {
        taco.material = selected;
    }
    public void Rotar()
    {
        
            rotateStatus = true;
        
        
    }
    public void norotar()
    {
        
            rotateStatus = false;
        
    }
}
