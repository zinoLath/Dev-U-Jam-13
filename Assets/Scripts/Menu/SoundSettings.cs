using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    bool musicState = true;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;
    [SerializeField] private UnityEngine.UI.Image _soundState;

    public void MusicSwtich()
    {
        musicState = !musicState;

        _sound.enabled = musicState;
        
        if(musicState == true)
        {
            _soundState.sprite = _on;
        }
        else
        {
            _soundState.sprite = _off;
        }
    }

    public void MusicVolume(float value)
    {
        _sound.volume = value;
    }

}
