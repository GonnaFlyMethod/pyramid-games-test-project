using TMPro;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance { get; private set; }

    [SerializeField] private GameObject _mainMenuGo;
    [SerializeField] private GameObject _timerGo;
    [SerializeField] private GameObject _gameOverGo;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        GameObject bestScoreText = _mainMenuGo.transform.Find("BestTimeText").gameObject;
            
        string bestScore = PlayerPrefs.GetString(GlobalConstants.PlayerPrefs.bestTime);

        if (bestScore == "")
        {
            bestScoreText.SetActive(false);
        }

        TextMeshProUGUI txtMeshPro = bestScoreText.GetComponent<TextMeshProUGUI>();

        txtMeshPro.text = "Best score: " + bestScore;

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        _mainMenuGo.SetActive(false);
        _timerGo.SetActive(true);

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _gameOverGo.SetActive(true);
        _timerGo.SetActive(false);

        GameObject txtGo = _timerGo.transform.Find("Text").gameObject;
        
        string bestTime = txtGo.GetComponent<TextMeshProUGUI>().text;

        PlayerPrefs.SetString(GlobalConstants.PlayerPrefs.bestTime, bestTime);

        Time.timeScale = 0;
    }
}
