using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzFallando : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration;
    public Color color0;
    public Color color1;
    bool encender = true;

    Light lt;

    void Start()
    {
        StartCoroutine("espera");
        lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color3
        if (encender)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color0, color1, t);
            encender = false;
            StartCoroutine("espera");
            Debug.Log("falso");
        }
    }
    IEnumerator espera()
    {
        Debug.Log("espero");
        yield return new WaitForSeconds(0.1f);
        encender = true;
    }
}
