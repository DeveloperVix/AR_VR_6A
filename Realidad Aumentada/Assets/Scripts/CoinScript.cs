using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("RedCubeTag"))
        {
            GameController.act.Puzzle5();
            Destroy(this.gameObject);
        }
    }
}
