using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particles;
    public bool OnTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ParticleOnView(bool Visible)
    {
        OnTarget = Visible;
        if (OnTarget == true)
        {

            particles.SetActive(true);
        }
        else
        {
            particles.SetActive(false);
        }
    }
}
