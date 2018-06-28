using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSong : MonoBehaviour {


    public void Change(AudioClip clip, AudioSource audioSource)
    {
        audioSource.clip = clip;
    }
}
