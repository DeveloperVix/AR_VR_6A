using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4 : MonoBehaviour
{
    private void Update()
    {
        if (transform.localScale.z >= 1.5f && transform.localScale.y >= 1.5f
            && transform.localScale.x >= 1.5f)
        {
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }
}
