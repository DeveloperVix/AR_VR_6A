using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{

    public Vector3 animationRot;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(animationRot*Time.deltaTime);
        if(Mathf.Abs(currentPos.y - this.transform.position.y) <= 1.5f)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
