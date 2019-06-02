using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public GameObject flag;
    public AudioSource myAudio;

    void Start()
    {
        Instantiate(flag,this.transform);
        this.transform.GetChild(0).name = this.transform.parent.gameObject.name + "Track";
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.GetChild(0).gameObject.activeSelf && !myAudio.isPlaying)//(this.transform.parent.gameObject.name + "Track" == this.transform.GetChild(0).gameObject.name)
        {
            myAudio.Play(); //Se ejecuta muchas veces ""Se buguea por ello"
            
        }
        else if (!this.transform.GetChild(0).gameObject.activeSelf)
        {
            myAudio.Pause();
        }
    }
}
