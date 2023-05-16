using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thirdweb;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public GameObject ScoreDisplayUI;
    public TMP_Text PickupScore;

    public string DROP_ERC1155_CONTRACT = "0x354433943A9F887644254827dEFf48EEc6becf65";    //= "0x354433943A9F887644254827dEFf48EEc6becf65";

    // Start is called before the first frame update
   async Task Start()
    {
        ScoreDisplayUI.SetActive(true);
        PickupScore.text = "You Picked Up " + playerData.Playerscore.ToString() + " NFTs";
        int NftToMint = playerData.Playerscore;

        if (NftToMint>0){ // Check if player picked up at least one Item (if not, mint nothing)
        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(DROP_ERC1155_CONTRACT);
            TransactionResult transactionResult = await contract.ERC1155.Claim("0", playerData.Playerscore);
            Debugger.Instance.Log("[Claim ERC1155] Successful", transactionResult.ToString());
        }
        catch (System.Exception e)
        {
            Debugger.Instance.Log("[Mint ERC1155] Error", e.Message);
        }
        }
        // Resetting Player Score to Zero
        playerData.Playerscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
