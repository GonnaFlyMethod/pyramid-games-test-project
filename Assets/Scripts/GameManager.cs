using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject _mainMenuGo;
    [SerializeField] private GameObject _timerGo;
    [SerializeField] private GameObject _gameOverGo;

    private static bool isRestartGame = false;


    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        if (isRestartGame) {
            StartGame();
            return;
        }


        GameObject bestTimeText = _mainMenuGo.transform.Find("BestTimeText").gameObject;
            
        float bestTime = PlayerPrefs.GetFloat(Global.Constants.PlayerPrefs.bestTime);

        if (bestTime == 0)
        {
            bestTimeText.SetActive(false);
        }
        else
        {
            TextMeshProUGUI txtMeshPro = bestTimeText.GetComponent<TextMeshProUGUI>();
            string bestTimeFormatted = Global.Funcs.FormatSeconds(bestTime); 

            txtMeshPro.text = "Best time: " + bestTimeFormatted;
        }

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

        float currentTime = _timerGo.GetComponent<Timer>().GetElapsedTime();
        string currentTimeFormatted = Global.Funcs.FormatSeconds(currentTime);

        _gameOverGo.transform.Find("CurrentTimeText")
            .GetComponent<TextMeshProUGUI>().text = "Current time: " + currentTimeFormatted;

        float bestTime = PlayerPrefs.GetFloat(Global.Constants.PlayerPrefs.bestTime);
        string bestTimeFormatted;

        if (bestTime == 0 || currentTime < bestTime)
        {
            PlayerPrefs.SetFloat(Global.Constants.PlayerPrefs.bestTime, currentTime);
            bestTimeFormatted = currentTimeFormatted;
        }
        else
        {
            bestTimeFormatted = Global.Funcs.FormatSeconds(bestTime);
        }
        

        _gameOverGo.transform.Find("BestTimeText")
            .GetComponent<TextMeshProUGUI>().text = "Best time: " + bestTimeFormatted;


        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        isRestartGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
