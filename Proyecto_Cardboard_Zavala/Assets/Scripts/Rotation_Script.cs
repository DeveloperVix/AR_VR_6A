using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Script : MonoBehaviour
{
    public bool rotating = false;
    float speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

}
