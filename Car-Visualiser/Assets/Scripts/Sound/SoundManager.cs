using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoSingletonGeneric<SoundManager>
{
    public Slider VolumeSlider;
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    [Range(0f, 1f)] public float userVolume;
    public float Volume = 1f;
    public SoundType[] Soundtypes;
    private void Start()
    {
        SetVolume(userVolume);
        PlayMusic(Sounds.music);
    }

    public void SetMusic()
    {
        if (SoundMusic.volume > 0)
        {
            SoundMusic.Stop();
        }
        else
        {
            SoundMusic.Play();
        }
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
        SoundEffect.volume = Volume;
        SoundMusic.volume = Volume;
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.loop = false;
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void PlayAudio(AudioClip sound)
    {
        AudioClip clip = sound;
        SetMusic();
        if (clip != null  && !SoundEffect.isPlaying)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
       
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType returnsound = Array.Find(Soundtypes, item => item.soundType == sound);
        if (returnsound != null)
        {
            return returnsound.soundclip;
        }
        return null;
    }

    public void StopEffect()
    {
        SoundEffect.Stop();
        SetMusic();
    }

}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundclip;
}
public enum Sounds
{
    ButtonClick,
    music
}

