using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupCount : MonoBehaviour
{
   public PlayerData playerData;  // Reference to the PlayerData script

   /* [SerializeField] private*/ public TMP_Text playerScore;  // Reference to the score Text component

    private void Awake()
    {
        // Find the score Text component on the PlayerScore GameObject
       // playerScore = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // Update the score UI text to match the score value in the ScoreData asset
        playerScore.text = "Score: " + playerData.Playerscore;
    }

    
}
