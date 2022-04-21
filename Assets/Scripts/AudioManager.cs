using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void PlayAudio(int audioNumber, float volumen)
    {
        controlAudio.PlayOneShot(audios[audioNumber], volumen);
    }
}
