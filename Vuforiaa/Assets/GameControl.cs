using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject[] winText;

    public static bool youWin;


    void Start()
    {
        //winText.setActive(false);
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0)
        {
            //winText.setActive(true);
            youWin = true;
            
        }
    }
}
