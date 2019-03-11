using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaFinal : MonoBehaviour
{
    public bool completado;

    // Start is called before the first frame update
    void Start()
    {
        completado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !completado)
        {
            GameObject GameObj = GameObject.Find("GameController");
            GameControllerARGame game = GameObj.GetComponent<GameControllerARGame>();
            game.PuzlesCompletados++;
            completado = true;
        }
    }
}
