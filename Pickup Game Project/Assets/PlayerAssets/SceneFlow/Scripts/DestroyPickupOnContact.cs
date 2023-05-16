using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; // for functions involving Await
using UnityEngine;
using Thirdweb;
using TMPro;

public class DestroyPickupOnContact : MonoBehaviour
{
    public TMP_Text playerScore;
    private int playerPickups = 1;
    public PlayerData PlayerData;
  
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {

        // Increment the score value in the ScoreData asset
        PlayerData.Playerscore += playerPickups;

        // Destroy the other game object
        Destroy(gameObject);
        Debug.Log("Abcdef");

          
    }
    
}
