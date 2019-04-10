using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INSERTARMATERIAL : MonoBehaviour
{
    public Material materialdefecto, selected;
    private MeshRenderer taco;
    // Start is called before the first frame update
    void Start()
    {
        taco = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Changecolor()
    {
        taco.material = materialdefecto;
    }
    public void ReturnColor()
    {
        taco.material = selected;
    }
}
