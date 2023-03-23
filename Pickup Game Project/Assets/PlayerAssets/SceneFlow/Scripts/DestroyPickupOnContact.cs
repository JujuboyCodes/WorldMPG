using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyPickupOnContact : MonoBehaviour
{
    public TMP_Text playerScore;
    private int playerPickups = 1;
    public PlayerData PlayerData;

   // public string pickupTag = "PickUp"; // The tag for the pickup items

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

       // playerPickups++;
       // playerScore.text = "Score: " + playerPickups.ToString();
        Debug.Log(playerPickups);
         Debug.Log("playerPickups");

       // Increment the score value in the ScoreData asset
        PlayerData.Playerscore += playerPickups;

        // Destroy the other game object
        Destroy(gameObject);
        
    }
}
