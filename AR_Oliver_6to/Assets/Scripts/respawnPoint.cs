using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPoint : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = respawnpoint.transform.position;
    }
}
