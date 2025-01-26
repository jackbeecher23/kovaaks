using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Logic : MonoBehaviour
{
  [Header("Game Settings")]
  public int playerScore;
  public int timeLimit;

  [Header("Displays")]
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI gameClock;
  public TextMeshProUGUI endScore;
  public GameObject gameOverScreen;

  [Header("Other Variables")]
  public float time;
  public int secondsClock;
  public int finalScore;
  public int cpc;

  /**************** Start ****************/
  /*
   * initialize game settings 
   */
  public void Start()
  {
    playerScore = 0;
    cpc = 1;
    time = 60;
    secondsClock = timeLimit;
  }

  /**************** Update ****************/
  /*
   * keep track of clock 
   */
  public void Update()
  {
    //float timer counting down
    time -= Time.deltaTime;

    //end game
    if ((int)time <= 0){
      gameOver();
    }

    //update seconds clock
    else if ((int)time < secondsClock){
      secondsClock = (int)time;
    }
    gameClock.text = secondsClock.ToString();

  }

  /**************** AddScore ****************/
  /*
   * manage players score 
   */
  public void AddScore()
  {
    playerScore++;
    scoreText.text = playerScore.ToString();
  }

  /**************** Restart ****************/
  /*
   * refresh the game settings 
   */
  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    Start();
  }

  /**************** gameOver ****************/
  /*
   * end game 
   */
  public void gameOver()
  {
    //save final score and display
    finalScore = playerScore;
    endScore.text = "Final Score: " + finalScore.ToString();

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    //display game over screen
    gameOverScreen.SetActive(true);
  }
}
