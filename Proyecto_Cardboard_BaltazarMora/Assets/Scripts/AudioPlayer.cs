using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioData;
    public bool OnTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioState(OnTarget);
    }

    public void audioState(bool visible)
    {
        OnTarget = visible;
        if (OnTarget == true)
        {
            audioData.UnPause();
            //Debug.Log("Playing audio... ");
        }

        else
        {
            audioData.Pause();
            //Debug.Log("Audio paused... ");            
        }
    }

}
