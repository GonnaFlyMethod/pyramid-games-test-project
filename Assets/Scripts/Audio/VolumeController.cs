using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeIncreaseSpeed;
    [SerializeField, Range(0.5f, 1)] private float _maxVolume;

    private float _volumedefault;
    private void Start()
    {
        _volumedefault = _audioSource.volume;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            _audioSource.volume = _volumedefault;
        }

        float audioSourceCurrentVolume = _audioSource.volume;
        
        if (audioSourceCurrentVolume != _maxVolume)
        {
            _audioSource.volume = Mathf.Lerp(
                audioSourceCurrentVolume, _maxVolume, _volumeIncreaseSpeed * Time.deltaTime);
        }

        if (1.0 - _audioSource.volume < 0.01)
        {
            _audioSource.volume = _maxVolume;
        }
    }
}
