using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAction : MonoBehaviour
{
    [SerializeField]
    protected Material off, on;

    private MeshRenderer meshRenderer;

    public bool IsOn;
    
    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !IsOn)
        {
            meshRenderer.material = on;
            IsOn = true;
            other.GetComponent<CapsuleMovement>().contador++;
        }
    }
}
