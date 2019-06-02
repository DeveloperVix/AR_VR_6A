using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Type of action/ShowParticles", fileName = "ShowParticles")]

public class ShowParticles : Interactive
{

    public GameObject bubbble;
    public GameObject thisObj;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }

    public override void Targeted()
    {
        Instantiate(bubbble,thisObj.transform);
    }

    public override void Untargeted()
    {
        Destroy(bubbble);
    }
}
