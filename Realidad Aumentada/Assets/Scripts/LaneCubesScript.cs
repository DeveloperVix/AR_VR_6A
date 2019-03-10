using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneCubesScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameController.act.puzzle5.activeInHierarchy)
        {
            StartCoroutine(WaitToStart());
        }

    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.Translate(Vector3.left * 0.005f);                                                               //Se crea un vector 3 que guardara la escala de la sphere

    }
}
