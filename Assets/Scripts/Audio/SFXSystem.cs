using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSystem : MonoBehaviour
{
    public static SFXSystem Instance { get; private set; }
    
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _chestOpenSFX;
    [SerializeField] AudioClip _keyCollectSFX;
    [SerializeField] AudioClip _keyRequiredSFX;
    [SerializeField] AudioClip _gameOjverSFX;
   
    private void Awake()
    {
        Instance = this;
    }

    public void PlayChestOpenSFX()
    {
        _audioSource.PlayOneShot(_chestOpenSFX);
    }

    public void PlayKeyCollectSFX()
    {
        _audioSource.PlayOneShot(_keyCollectSFX);
    }

    public void PlayKeyRequiredSFX()
    {
        _audioSource.PlayOneShot(_keyRequiredSFX);
    }

    public void PlayGameOverSFX()
    {
        _audioSource.PlayOneShot(_gameOjverSFX);
    }
}
