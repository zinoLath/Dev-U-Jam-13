using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private static AudioSource _audioSource;
   private static AudioClip _laser, _shot;

    void Start()
    {
        _laser = Resources.Load<AudioClip>("Laser");
        _shot = Resources.Load<AudioClip>("Shot");

        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Laser":
                _audioSource.PlayOneShot(_laser);
                break;
            case "Shot":
                _audioSource.PlayOneShot(_shot);
                break;
        }
    }
}
