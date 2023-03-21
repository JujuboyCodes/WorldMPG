using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameObject startObject; // The game object assigned to the start state
    public GameObject pauseObject; // The game object assigned to the pause state
    public GameObject gameOverObject; // The game object assigned to the game over state
    public GameState currentState = GameState.Null; // The current game state
    public GameState prevState = GameState.Null;

    // Enum for the game states
    public enum GameState
    {
        Null,
        Start,
        Pause,
        GameOver
    }

     public GameState GetCurrentState()
    {
        return currentState;
    }

    void Start()
    {
        // Set the initial game state to "Start"
        SetState(GameState.Start);
    }

    void Update()
    {
        // Check for input to toggle the pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseState();
        }
    }

    // Function to set the game state
    public void SetState(GameState newState)
    {
        // Deactivate all game objects
        startObject.SetActive(false);
        pauseObject.SetActive(false);
        gameOverObject.SetActive(false);

        // Set the new game state
        currentState = newState;

        // Activate the game object assigned to the new game state
        switch (currentState)
        {
            case GameState.Start:
                startObject.SetActive(true);
                break;
            case GameState.Pause:
                pauseObject.SetActive(true);
                break;
            case GameState.GameOver:
                gameOverObject.SetActive(true);
                break;
        }
    }

    // Function to toggle the pause state
    public void TogglePauseState()
    {
        // If the current state is "Pause", switch to the previous state
        if (currentState == GameState.Pause)
        {
            switch (prevState)
            {
                case GameState.Start:
                    SetState(GameState.Start);
                    break;
                case GameState.GameOver:
                    SetState(GameState.GameOver);
                    break;
            }
        }
        // If the current state is not "Pause", switch to the "Pause" state
        else
        {
            prevState = currentState;
            SetState(GameState.Pause);
        }
    }

    // Function to handle the countdown complete event from the Start game object
    public void StartCountdownComplete()
    {
        // Switch to the "Game Over" state
        SetState(GameState.GameOver);
    }

     public void GoBackHome()
    {
      SceneManager.LoadScene("HomeScene");
    }
}

