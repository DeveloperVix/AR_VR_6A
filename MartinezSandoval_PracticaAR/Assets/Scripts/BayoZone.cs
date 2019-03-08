using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayoZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (GM_ARScene.act.bayoMove) return;
        if (other.tag == "Player")
        {

            if (!GM_ARScene.act.objWin.activeInHierarchy) GM_ARScene.act.objWin.SetActive(true);
        }
    }
}
