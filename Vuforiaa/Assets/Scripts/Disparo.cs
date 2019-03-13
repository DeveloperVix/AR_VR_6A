using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public GameObject misil;
    bool Shooting = false;

    void Start()
    {
        StartCoroutine("ShootingProcess");
    }

    IEnumerator ShootingProcess()
    {

        while (true)
        {
            if (Shooting)
            {
                Instantiate(misil, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

