using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{

    public Material matNormal, matSelect;
    [HideInInspector]
    public Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HoverChange(bool val)
    {
        render.material = val ? matSelect : matNormal;
    }
}
