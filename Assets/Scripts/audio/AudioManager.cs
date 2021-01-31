using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
#pragma warning disable 0649
    [SerializeField]
    private AudioClip musicTrack;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioSource textSource;
#pragma warning disable 0649

    public float MusicVolume { get => musicSource.volume; set { musicSource.volume = value; } }
    public float EffectVolume { get => effectSource.volume; set { effectSource.volume = value; } }
    public float TextVolume { get => textSource.volume; set { textSource.volume = value; } }

    public float LowPitchRange = 0f;
    public float HighPitchRange = 0.1f;

    protected override void Awake()
    {
        MusicVolume = ConfigManager.Instance.MusicVolume;
        EffectVolume = ConfigManager.Instance.EffectVolume;
        TextVolume = ConfigManager.Instance.TextVolume;
        base.Awake();
    }

    private void Start() => PlayMusic();

    public void PlayMusic()
    {
        musicSource.loop = true;
        musicSource.clip = musicTrack;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayText(AudioClip clip)
    {
        textSource.clip = clip;
        textSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomizePitch(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        textSource.pitch = randomPitch;
        textSource.clip = clips[randomIndex];
        textSource.Play();
    }
}
