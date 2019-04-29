using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Scriptable/Audio", fileName ="Audio")]
public class AudioVR : Scriptables
{
    public AudioVR()
    {
        type = Type.Audio;
        audioSource = null;
    }

    public AudioClip clip;
    private AudioSource audioSource = null;

    public override void OnNotSeen(GameObject obj)
    {
        CheckAudioSource(obj);
        if (audioSource.isPlaying) audioSource.Stop();
    }

    public override void OnSeen(GameObject obj)
    {
        CheckAudioSource(obj);
        if (!audioSource.isPlaying) audioSource.Play();
    }

    void CheckAudioSource(GameObject obj)
    {
        if (audioSource == null)
        {
            audioSource = obj.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.loop = true;
        }
    }
}
