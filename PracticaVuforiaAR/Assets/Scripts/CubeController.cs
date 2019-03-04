using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CubeController : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;
    public GameObject particle;
    public Animator animatorII;
    public Animator animatorIII;

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (statusImg.isDetected )
        {
            Debug.Log("Inicia Pantalla");
            PlayButton();

        }
    }

    public void PlayButton()
    {

        Instantiate(particle);
        Instantiate(animatorII);
        Instantiate(animatorIII);
    }
}
