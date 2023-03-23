using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public GameObject ScoreDisplayUI;
    public TMP_Text PickupScore;

    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplayUI.SetActive(true);
        PickupScore.text = "You Picked Up " + playerData.Playerscore.ToString() + " NFTs";
        
        // Resetting Player Score to Zero
        playerData.Playerscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   /* private IEnumerator ShowPickupScore()
    {
        
    }*/
}
