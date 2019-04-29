using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    public GameObject text;
    public bool OnTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayOnScreen(bool Visible)
    {
        OnTarget = Visible;
        if (OnTarget == true)
        {
            //transform.Rotate(new Vector3(0, 5, 0));
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
