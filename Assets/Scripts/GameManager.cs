using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Paddle playerPaddle;
    public int playerScore { get; private set; }
    public Text playerScoreText;

    public Paddle computerPaddle;
    public int computerScore { get; private set; }
    public int AudioListener { get; private set; }

    public Text computerScoreText;

    public GameObject GameOverUI;
    public GameObject HighscoreUI;
    public TMPro.TMP_InputField NameInputField;
    public HighscoreManager HighscoreManager;

    private void Awake()
    {
        GameOverUI.SetActive(false);
        HighscoreUI.SetActive(false);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        if(playerScore > computerScore)
        {
            var isNewHighscore = HighscoreManager.IsNewHighscore(playerScore);
            HighscoreUI.SetActive(isNewHighscore);
        }

        //var isNewHighscore = HighscoreManager.IsNewHighscore(playerScore);
        //HighscoreUI.SetActive(isNewHighscore);        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddHightscore()
    {
        var playerName = NameInputField.text;

        if (string.IsNullOrWhiteSpace(playerName))
        {
            return;
        }

        HighscoreManager.Add(playerName, playerScore);
        HighscoreUI.SetActive(false);
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
    }

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        SetPlayerScore(playerScore + 1);
        StartRound();
    }

    public void ComputerScores()
    {
        SetComputerScore(computerScore + 1);
        StartRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
