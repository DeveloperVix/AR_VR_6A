using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Transform head, mainCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PoolingManager.act.queueBalas.Count == 0) return;
            
            GameObject obj = PoolingManager.act.CallBullet(head.localPosition, mainCamera.localRotation);
            obj.SetActive(true);
        }

    }
}
