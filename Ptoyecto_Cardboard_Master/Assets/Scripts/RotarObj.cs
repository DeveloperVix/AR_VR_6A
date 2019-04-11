using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarObj : MonoBehaviour,IInteractable
{
    public bool canRotate = false;
    public float speed = 10;
    public void LookOnMe()
    {
        canRotate = true;
    }

    public void NoLookOnMe()
    {
        canRotate = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
    }
}
