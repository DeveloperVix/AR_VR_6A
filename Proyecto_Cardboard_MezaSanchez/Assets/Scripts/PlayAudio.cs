using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Type of action/PlayAudio", fileName = "PlayAudio")]

public class PlayAudio : Interactive
{
    public GameObject audioTest;
    public GameObject flag;
    public AudioSource clip;


    public override void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }

    public override void Targeted()
    {
        Debug.Log("Play");
        clip.Play();
    }

    public override void Untargeted()
    {
        Debug.Log("Pause");
        clip.Pause();
    }
}
