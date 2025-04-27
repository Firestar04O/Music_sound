using UnityEngine;
using UnityEngine.Audio;
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ChannelPlayer musicPlayer;
    [SerializeField] private ChannelPlayer sfxPlayer;

    private void OnEnable()
    {
        InteractableObjects.OnCollisionMusic += PlayPlayer;
    }
    private void OnDisable()
    {
        InteractableObjects.OnCollisionMusic -= PlayPlayer;

    }
    public void PlayPlayer(AudioMixerGroup currentGroup, AudioClip currentAudioClip)
    {

        if (currentGroup == musicPlayer.PlayerChannel)
        {
            musicPlayer.PlayClip(currentAudioClip);
        }
        else
        {
            sfxPlayer.PlayClip(currentAudioClip);
        }
    }
}
