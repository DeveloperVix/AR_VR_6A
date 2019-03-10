using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

public class PlayAudio : MonoBehaviour
{

    public AudioSource asd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            asd.Play();
        }
    }
}
