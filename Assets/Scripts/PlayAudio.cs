using System.Collections;
using UnityEngine;

public class PlayAudio : MonoBehaviour

{
    public void Play(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}

