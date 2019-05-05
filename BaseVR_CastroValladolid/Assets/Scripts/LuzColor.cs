using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzColor : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 1.0f;
    public Color color0 ;
    public Color color1;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
