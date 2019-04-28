using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject bubbles;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(bubbles, new Vector3(Random.Range(this.transform.position.x - .3f, this.transform.position.x + .3f), this.transform.position.y, Random.Range(this.transform.position.z - .3f, this.transform.position.z + .3f)), Quaternion.identity);
        spawn();
    }
}
