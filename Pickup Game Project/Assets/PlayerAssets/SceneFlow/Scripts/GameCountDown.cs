using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCountDown : MonoBehaviour
{

    public TMP_Text countDownText;
    public float countDownDuration = 60f;

    public GameObject CountDownUI;

    private float timeLeft;
    private bool isPaused = false;
    private GameStateController gameStateController;

    public GameObject GameOverState;

    private void Start()
    {
        timeLeft = countDownDuration;
        gameStateController = GameObject.FindObjectOfType<GameStateController>();
    }

    private void Update()
    {
        Time.timeScale = 1f;
        if (gameStateController.currentState == GameStateController.GameState.Start && !isPaused)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                Debug.Log("Countdown complete");
                CountDownUI.SetActive(false);
                gameObject.SetActive(false);
                GameOverState.SetActive(true);                 
                return;
                
            }

            int minutesLeft = Mathf.FloorToInt(timeLeft / 60f);
            int secondsLeft = Mathf.FloorToInt(timeLeft % 60f);

            string minutesString = minutesLeft.ToString("D2");
            string secondsString = secondsLeft.ToString("D2");

            countDownText.text = minutesString + ":" + secondsString;
        }

        
    }

    public void PauseCountDown()
    {
        isPaused = true;
    }

    public void ResumeCountDown()
    {
        isPaused = false;
    }
}
