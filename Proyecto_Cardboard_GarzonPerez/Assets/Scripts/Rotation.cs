using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Mat
{
    bool detected = false;
    void Update()
    {
        if (!detected)
        {
            transform.Rotate(0, 10 * Time.deltaTime, 0);
        }
        else if (detected) ;
        transform.Rotate(0, 0, 0);
    }
    public override void cambioColor(bool col)
    {
        base.cambioColor(col);
        detected = col;
    }
}