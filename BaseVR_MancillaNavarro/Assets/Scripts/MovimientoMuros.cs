using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMuros : MonoBehaviour
{
    public GameObject obj;
    Rigidbody rb;
    public float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Alto"))
        {
           // fuerza = 0;
            StartCoroutine("inicia");

        }
        if (col.tag.Equals("Muro"))
        {

            rb.velocity = new Vector3(0, 0, 0);
            StartCoroutine("espera");

        }
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1);

        rb.velocity = new Vector3(0, 0, -fuerza);
    }
    IEnumerator inicia()
    {

        rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1);

        rb.velocity = new Vector3(0, 0, fuerza);
    }
}
