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
        _timeText.text = Global.Funcs.FormatSeconds(_elapsedTime);
    }
}

// Global should have function - FormatElapsedSeconds
// This function should be called in MainSceen and game over screen
// Save user prefs as float
