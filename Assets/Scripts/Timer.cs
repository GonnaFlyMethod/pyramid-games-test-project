using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    
    private float _elapsedTime;

    public float GetElapsedTime() { return _elapsedTime; }

    // Update is called once per frame
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        float secondsAsMiliseconds = _elapsedTime % 60 * 1000;
        int seconds = Mathf.FloorToInt(secondsAsMiliseconds / 1000);
        int miliseconds = Mathf.FloorToInt(secondsAsMiliseconds % 1000);

        _timeText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", 
            minutes, seconds, miliseconds);
    }
}

// Global should have function - FormatElapsedSeconds
// This function should be called in MainSceen and game over screen
// Save user prefs as float
