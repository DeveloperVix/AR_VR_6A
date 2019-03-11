using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public GameObject plane;
    public GameObject spawn;
    public static bool si = false;
    public GameObject goal;
    public Text ganaste;
    

    // Start is called before the first frame update
    void Start()
    {
        ganaste.gameObject.SetActive(false);
        if(si == true)
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < plane.transform.position.z -5)
        {
            transform.position = spawn.transform.position;
            Debug.Log("respawn");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Win")
        {
            ganaste.gameObject.SetActive(true);
            ChallengeController.primerDesafio = true;
        }
    }

}
