using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public int highScore =1;
    public TextMeshProUGUI highScoreText;

    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject pausePanel;

    public static bool isGameStartedOnce=false;

    public AudioClip hitSound;
    public AudioClip scoreSound;
    public AudioSource audioSource;

    void Start()
    {
        scoreText.text = "Score: 0";
        highScore=PlayerPrefs.GetInt("HighScore",0);
        highScoreText.text = $"High Score: {highScore}";
        gameOverPanel.SetActive(false);

        if (isGameStartedOnce)
        {
            Time.timeScale = 1f;
            startPanel.SetActive(false);
        }
        else
        {
            Time.timeScale= 0f;
            startPanel.SetActive(true);
        }
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f)
        {
            PauseGame();
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        audioSource.PlayOneShot(scoreSound);
    }

    public void GameOver()
    {
        if (highScore<score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = $"High Score: {highScore}";
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(hitSound);
        Time.timeScale = 0f; // stop game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
        isGameStartedOnce = true;

        highScoreText.text = $"High Score: {highScore}";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    [ContextMenu("Reset High Score")]
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

}
