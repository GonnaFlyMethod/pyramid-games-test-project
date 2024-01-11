using UnityEngine;

public class SmoothVolumeIncreaser : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeIncreaseSpeed;

    // Update is called once per frame
    private void Update()
    {
        float audioSourceCurrentVolume = _audioSource.volume;
        
        if (audioSourceCurrentVolume != 1)
        {
            _audioSource.volume = Mathf.Lerp(
                audioSourceCurrentVolume, 1, _volumeIncreaseSpeed * Time.deltaTime);
        }

        if (1.0 - _audioSource.volume < 0.01)
        {
            _audioSource.volume = 1;
        }
    }
}
