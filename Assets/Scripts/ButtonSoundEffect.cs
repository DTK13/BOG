using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonHover;
    public AudioClip buttonClick;

    public void HoverSound()
    {
        audioSource.PlayOneShot(buttonHover);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
