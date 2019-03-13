using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Back : MonoBehaviour
{
    public GameObject win;
    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        boton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (win.activeInHierarchy)
        {
            boton.SetActive(true);
        }
        else
        {
            boton.SetActive(false);
        }
    }
    public void OnClick()
    {
        win.SetActive(false);
    }
}
