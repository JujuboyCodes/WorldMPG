using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownController : MonoBehaviour
{
     public float countdownTime = 5f; // The initial countdown time in seconds
    [SerializeField]
    private TMP_Text countdownText; // The Text element that displays the countdown
    public delegate void CountdownCompleteHandler(); // Declare a delegate for the CountdownComplete event
    public event CountdownCompleteHandler CountdownComplete; // Declare the CountdownComplete event
    public GameObject GameStateController; // Declare the GameObject variable and assign it in the Inspector
    public GameObject GameCountDownCanvas;
    public GameObject CountDownContainer;
    void Start()
    {
        // Get the Text component from the game object
        //countdownText = GetComponent<TMP_Text>();
        CountDownContainer.SetActive(true);
    }

    void Update()
    {
        // Decrement the countdown time by the elapsed time since the last frame
        countdownTime -= Time.deltaTime;

        // Check if the countdown has reached zero
        if (countdownTime <= 0f)
        {
            // Set the countdown text to "0"
            countdownText.text = "0";

            // Invoke the CountdownComplete event
            if (CountdownComplete != null)
            {
                CountdownComplete();
            }

            // Set the Text component's game object to inactive
            gameObject.SetActive(false);
            GameCountDownCanvas.SetActive(true);
            GameStateController.SetActive(true);
            
        }
        else
        {
            // Round the countdown time to the nearest integer
            int roundedTime = Mathf.RoundToInt(countdownTime);

            // Update the countdown text with the rounded time
            countdownText.text = roundedTime.ToString();
        }
    }
}