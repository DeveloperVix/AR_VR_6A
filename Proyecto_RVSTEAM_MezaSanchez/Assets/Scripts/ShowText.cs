using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Type of action/ShowText", fileName = "ShowText")]

public class ShowText : Interactive
{

    public GameObject text;

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
        text.SetActive(true);
    }

    public override void Untargeted()
    {
        text.SetActive(false);
    }
}
