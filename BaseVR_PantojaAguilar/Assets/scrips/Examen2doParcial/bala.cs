using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float vel;
    public float recarga;
    float istacia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= istacia)
        {
            PoolingManager.sing.NoBalas(gameObject);
        }
        transform.position += Vector3.forward * vel * Time.deltaTime;
    }
}
