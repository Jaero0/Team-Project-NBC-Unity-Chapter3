using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;


public class SoundManager : StartMeunManager

{
    public AudioSource musicSource;
    public AudioSource btnSounrce_go;
    public AudioSource btnSounrce_Character;


    private void Start()
    {
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetButtonVolume(float volume)
    {
        btnSounrce_go.volume = volume;
        btnSounrce_Character.volume = volume;
    }

    public void OnSfx()
    {
        btnSounrce_go.Play();
    }
    public void OnCharecter()
    {
        btnSounrce_Character.Play();
    }
}