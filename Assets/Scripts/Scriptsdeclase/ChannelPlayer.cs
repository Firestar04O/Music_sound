using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ChannelPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSettings audioSettings;
    public AudioMixerGroup PlayerChannel => audioSource.outputAudioMixerGroup;
    private void Awake()
    {
        audioSource.outputAudioMixerGroup = audioSettings.AudioMixerGroup;
        audioSource.loop = true;
    }
    public void PlayClip(AudioClip clipToPlay, bool loop = false)
    {
        if (loop)
        {
            audioSource.Stop();
            audioSource.loop = loop;
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }
}