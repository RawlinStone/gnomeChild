using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : Singleton<ConfigManager>
{
#pragma warning disable 0649
    [Header("Audio")]
    [SerializeField]
    private float musicVolume;
    [SerializeField]
    private float effectVolume;
    [SerializeField]
    private float textVolume;
#pragma warning disable 0649

    public float MusicVolume
    {
        get => musicVolume; set
        {
            musicVolume = value;
            AudioManager.Instance.MusicVolume = value;
        }
    }
    public float EffectVolume
    {
        get => effectVolume; set
        {
            musicVolume = value;
            AudioManager.Instance.EffectVolume = value;
        }
    }
    public float TextVolume
    {
        get => textVolume; set
        {
            musicVolume = value;
            AudioManager.Instance.TextVolume = value;
        }
    }
}
