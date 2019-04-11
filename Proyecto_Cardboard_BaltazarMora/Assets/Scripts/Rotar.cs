using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{

    

    public bool OnTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(OnTarget);
    }

    public void Rotate(bool Visible)
    {
        OnTarget = Visible;
        if (OnTarget == true)
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
    }

}
