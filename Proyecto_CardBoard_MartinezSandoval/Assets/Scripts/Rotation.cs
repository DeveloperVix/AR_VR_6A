using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Selected
{

    bool detected = false;

    void Update()
    {
        if (!detected)
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    public override void HoverChange(bool val)
    {
        base.HoverChange(val);
        detected = val;
    }
}
