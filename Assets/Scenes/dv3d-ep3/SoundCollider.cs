using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SoundCollider : MonoBehaviour
{
    public AudioSource audioSource;
    public bool pauseOnBadCollision = true;


    void OnValidate()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        isPlaying(true);
    }

    private void OnCollisionExit(Collision other)
    {
        isPlaying();
    }

    private void isPlaying(bool play = false)
    {
        if (play)
            audioSource.Play();
        else
            audioSource.Pause();
    }

    bool isAlright(Collider other)
    {
        return true;
    }
}
