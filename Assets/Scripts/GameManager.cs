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

    private void Awake()
    {
        Instance = this;

        if (isRestartGame) {
            StartGame();
            return;
        }

        GameObject bestTimeText = _mainMenuGo.transform
            .Find(Global.Constants.ObjectNames.bestTimeTxt).gameObject;
            
        float bestTime = PlayerPrefs.GetFloat(Global.Constants.PlayerPrefs.bestTime);

        if (bestTime == 0)
        {
            bestTimeText.SetActive(false);
        }
        else
        {
            TextMeshProUGUI txtMeshPro = bestTimeText.GetComponent<TextMeshProUGUI>();
            string bestTimeFormatted = Global.Funcs.FormatSeconds(bestTime); 

            txtMeshPro.text = Global.Constants.StringTemapltes.bestTime + bestTimeFormatted;
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

        // Finding "current time text" within game over object
        GameObject currentTimeGO = _gameOverGo.transform
            .Find(Global.Constants.ObjectNames.currentTimeTxt).gameObject;

        string currentTimePresentation = Global.Constants.StringTemapltes.currentTime + currentTimeFormatted;
        currentTimeGO.GetComponent<TextMeshProUGUI>().text = currentTimePresentation;

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

        GameObject bestTimeGO = _gameOverGo.transform
            .Find(Global.Constants.ObjectNames.bestTimeTxt).gameObject;

        string bestTimePresentation = Global.Constants.StringTemapltes.bestTime + bestTimeFormatted;
        bestTimeGO.GetComponent<TextMeshProUGUI>().text = bestTimePresentation;

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        isRestartGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
