using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Scriptable/Audio", fileName ="Audio")]
public class AudioVR : Scriptables
{
    public AudioVR()
    {
        type = Type.Audio;
        audio = null;
    }

    public AudioClip clip;
    private AudioSource audio = null;

    public override void OnNotSeen(GameObject obj)
    {
        ReviewAudio(obj);
        if (audio.isPlaying) audio.Stop();
    }

    public override void OnSeen(GameObject obj)
    {
        ReviewAudio(obj);
        if (!audio.isPlaying) audio.Play();
    }

    void ReviewAudio(GameObject obj)
    {
        if (audio == null)
        {
            audio = obj.AddComponent<AudioSource>();
            audio.clip = clip;
            audio.loop = true;
        }
    }
}
