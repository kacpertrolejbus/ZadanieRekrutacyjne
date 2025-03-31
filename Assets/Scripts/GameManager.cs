using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score; 
    private int highScore; 
    public PlayerMovement player; 
    public Text scoreText; 
    public Text highScoreText; 
    public GameObject gameOverPanel; 
    public Text startText; 
    public Button playButton; 

    private void Start()
    {
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        
        UpdateScoreUI();
        Pause();
        startText.gameObject.SetActive(true); 
        gameOverPanel.SetActive(false); 

        
        playButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0f)
        {
            
            Play();
        }
    }

    public void Play()
    {
        
        score = 0;
        UpdateScoreUI();
        startText.gameObject.SetActive(false); 
        gameOverPanel.SetActive(false); 

        Time.timeScale = 1f; 
        player.enabled = true; 
    }

    public void Pause()
    {
        Time.timeScale = 0f; 
        player.enabled = false; 
    }

    public void GameOver()
    {
        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); 
            PlayerPrefs.Save();
        }

        gameOverPanel.SetActive(true); 
        Pause(); 
    }

    public void IncreaseScore()
    {
        score+=5; 
        UpdateScoreUI();

        if (score > highScore)
        {
            highScore = score; 
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void RestartGame()
    {
        
        foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            Destroy(obj);
        }

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); 
        highScoreText.text = highScore.ToString(); 
    }
}