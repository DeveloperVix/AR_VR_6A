using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        transform.Rotate(0f, 90f, 0f);
    }
}
