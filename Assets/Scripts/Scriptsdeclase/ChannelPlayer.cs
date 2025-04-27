using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ChannelPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSettings audioSettings;

    [Header("Music Start")]
    [SerializeField] private bool playMusicOnStart = false;
    [SerializeField] private AudioData audioData;
    public AudioMixerGroup PlayerChannel => audioSource.outputAudioMixerGroup;
    private void Awake()
    {
        audioSource.outputAudioMixerGroup = audioSettings.AudioMixerGroup;
        audioSource.loop = true;
    }
    private void Start()
    {
        if (playMusicOnStart && audioData != null)
        {
            PlayClip(audioData.AudioClip, true);
        }
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
            CreateTempAudioSource(clipToPlay);
        }

    }
    private void CreateTempAudioSource(AudioClip clip)
    {
        GameObject tempAudio = new GameObject("TempAudioSource");
        tempAudio.transform.position = transform.position;

        AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
        tempSource.outputAudioMixerGroup = audioSettings.AudioMixerGroup;
        tempSource.clip = clip;
        tempSource.Play();

        Destroy(tempAudio, clip.length);
    }
}