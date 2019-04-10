using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{

    public Material matNormal, matSelect;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverChange(bool val)
    {
        renderer.material = val ? matSelect : matNormal;
    }
}
