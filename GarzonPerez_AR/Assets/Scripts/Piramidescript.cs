using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piramidescript : MonoBehaviour
{
    VideoScript vid;

    public GameObject Base;
    public GameObject Media;
    public GameObject ButtonBase;
    public GameObject ButtonMedia;
    public GameObject winn;

    float y, z;
    float y1, z1;
    float y2, z2;


    void Start()
    {
        Base = GetComponent<GameObject>();
        Media = GetComponent<GameObject>();

    }
    void Update()
    {
        if (y >= 0.7 && z >= 0.7)
        {
            Destroy(ButtonBase);
            ButtonMedia.SetActive(true);
        }
        if (y1 >= 0.4 && z1 >= 0.4 && ButtonBase == null)
        {
            ButtonMedia.SetActive(false);
            StartCoroutine("Puzzle3"); 
        }

    }
    public void aumentarY()
    {
        y = y + 0.1f;
        if (y >= 0.7f)
        {
            y = 0.71f;
        }
        else
        {
            Base.transform.localScale = new Vector3(0.17f, y, z);
        }
    }
    public void aumentarZ()
    {
        z = z + 0.1f;
        if(z >= 0.7f)
        {
            z = 0.71f;
        }
        else
        {
            Base.transform.localScale = new Vector3(0.17f, y, z);
        }
    }

    public void aumentarYMedia()
    {
        y1 = y1 + 0.1f;
        if (y1 >= 0.5f)
        {
            y1 = 0.51f;
        }
        else
        {
            Media.transform.localScale = new Vector3(0.17f, y1, z1);
        }
    }
    public void aumentarZMedia()
    {
        z1 = z1 + 0.1f;
        if (z1 >= 0.5f)
        {
            z1 = 0.51f;
        }
        else
        {
            Media.transform.localScale = new Vector3(0.17f, y1, z1);
        }
    }
    IEnumerator Puzzle3()
    {
        winn.SetActive(true);
        yield return new WaitForSeconds(2f);
        winn.SetActive(false);
    }
}