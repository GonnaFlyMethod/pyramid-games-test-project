using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    public static MusicSystem Instance { get; private set; }
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _poolOfCompositions;

    private int _indexOfCurrentComposition = -1;
    private bool stoppedIntentionally = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (_indexOfCurrentComposition == -1)
        {
            return;
        }

        if (stoppedIntentionally)
        {
            return;
        }

        if (!_audioSource.isPlaying)
        {
            PickAndPlayRandomMusic();
        }
    }

    public void PickAndPlayRandomMusic()
    {
        int indexOfComposition;

        while (true)
        {
            indexOfComposition = Random.Range(0, _poolOfCompositions.Count);

            if (indexOfComposition == _indexOfCurrentComposition)
            {
                continue;
            }

            break;
        }


        _indexOfCurrentComposition = indexOfComposition;

        AudioClip audioClipToPlay = _poolOfCompositions[indexOfComposition];

        _audioSource.clip = audioClipToPlay;
        _audioSource.Play();
    }

    public void StopPlayer() {
        stoppedIntentionally = true;
        _audioSource.Stop();
    }
}
