using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaCol : MonoBehaviour
{
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Equals("Cube (11)"))
        {
            finish = true;
            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            meshRend.material.color = Color.cyan;
        }
    }
}
