using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    private Rigidbody myrigidbody;
    private float horizontal;
    private float transversal;
    public int speed;
    public AudioPlayer music;
    public AudioSource sound;
    public AudioSettings SFX;
    public AudioData walk;
    private void Awake()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        myrigidbody.velocity = new Vector3(horizontal * speed, 0, transversal * speed);
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
        if (!sound.isPlaying)
        {
            music.PlayPlayer(SFX.AudioMixerGroup, walk.AudioClip);
        }
        if (context.ReadValue<float>() == 0)
        {
            sound.Stop();
        }
    }
    public void OnMovementY(InputAction.CallbackContext context)
    {
        transversal = context.ReadValue<float>();
        if (!sound.isPlaying)
        {
            music.PlayPlayer(SFX.AudioMixerGroup, walk.AudioClip);
        }
        if (context.ReadValue<float>() == 0)
        {
            sound.Stop();
        }
    }
    //public void OnJumping()
    //{

    //}
}
