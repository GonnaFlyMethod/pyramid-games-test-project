using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _timeText.text = Global.Funcs.FormatSeconds(_elapsedTime);
    }

    public float GetElapsedTime() { return _elapsedTime; }
}
