using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRitcle : MonoBehaviour {

    public float time = 0f;
    public GameObject[] bar;

    public bool look = false;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < bar.Length; i++)
        {
            bar[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (look)
        {
            time += Time.deltaTime;

            if (time >= 1f)
            {
                bar[0].SetActive(true);
            }
            if (time >= 2f)
            {
                bar[1].SetActive(true);
            }
            if (time >= 3f)
            {
                bar[2].SetActive(true);
                Debug.Log("Algo pasara");
            }
        }
    }

    public void Looking()
    {
        look = true;
    }

    public void Reset()
    {
        look = false;
        time = 0f;
        for (int i = 0; i < bar.Length; i++)
        {
            bar[i].SetActive(false);
        }
    }
}
