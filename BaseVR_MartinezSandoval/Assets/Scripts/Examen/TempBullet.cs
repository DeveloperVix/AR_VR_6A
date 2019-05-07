using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    public float speed;
    public float timeReCall;
    float timeCall;

    private void Update()
    {
        if (Time.time >= timeCall) PoolingManager.act.ReturnBullet(gameObject);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        timeCall = Time.time + timeReCall;
    }
}
