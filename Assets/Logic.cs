using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Logic : MonoBehaviour
{
  public int playerScore;
  public float time;
  public int secondsClock;
  public int timeLimit;
  public int cpc;
  public int cps;
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI gameClock;
  public TextMeshProUGUI endScore;
  public GameObject gameOverScreen;
  public int finalScore;


  public void Start()
  {
    playerScore = 0;
    cpc = 1;
    cps = 0;
    time = 60;
    secondsClock = timeLimit;
  }

  public void Update()
  {
    time -= Time.deltaTime;
    if ((int)time <= 0){
      gameOver();
    }
    else if ((int)time < secondsClock){
      secondsClock = (int)time;
    }
    gameClock.text = secondsClock.ToString();

  }

  public void AddScore()
  {
    playerScore++;
    scoreText.text = playerScore.ToString();
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    Start();
  }

  public void gameOver()
  {
    finalScore = playerScore;
    endScore.text = "Final Score: " + finalScore.ToString();

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    gameOverScreen.SetActive(true);
  }
}
