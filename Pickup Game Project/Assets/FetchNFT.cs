using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Thirdweb;

public class FetchNFT : MonoBehaviour
{
    public GameObject GreenSignal;
    public GameObject RedSignal;



    public string Nft1155Contract; // NFT1155 Contract Address to run nft operations on
    public string Nft721Contract;  // NFT721 Contract Address to run nft operations on
    public string ERC20Contract;   // ERC20 Contract Address to run nft operations on

    //public string NftID;         // Nft Token ID

    public static CurrencyValue PlayerBalance;

    ThirdwebSDK sdk;

    // Start is called before the first frame update
    void Start()
    {
        sdk = new ThirdwebSDK("optimism-goerli");
        GreenSignal.SetActive(false);
        RedSignal.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ToggleBalance()
    {
        await CheckNftBalance();
    }

    public async Task<string> CheckNftBalance() // Check if User address Holds any nfts
    {
       
       string address =  await ThirdwebManager.Instance.SDK.wallet.Connect();
       Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x354433943A9F887644254827dEFf48EEc6becf65"); 
       string balance = await contract.ERC1155.BalanceOf("0x5BEB686A9C479d1f0F7008C3a6074814194736e1", "0"); // Parameters provided (address, token id)
       
      
       Debug.Log(address);
       Debug.Log("NFT balance: "+ balance);
     
       return balance;
      
    }   


      public async void FetchERC20()
    {
        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ERC20Contract);

            Currency currencyInfo = await contract.ERC20.Get();
            Debugger.Instance.Log("[Fetch ERC20] Get", currencyInfo.ToString());

            PlayerBalance = await contract.ERC20.Balance();  // Returns balance of players ERCToken
            
            string Balance = PlayerBalance.ToString();
            // CurrencyValue currencyValue = await contract.ERC20.TotalSupply();
        }
        catch (System.Exception e)
        {
            Debugger.Instance.Log("[Fetch ERC20] Error", e.Message);
        }
    }


    public async void MintNFT()
    {
        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(Nft1155Contract);
            TransactionResult transactionResult = await contract.ERC1155.Claim("0", 1);
            Debugger.Instance.Log("[Claim ERC1155] Successful", transactionResult.ToString());

            
        }
        catch (System.Exception e)
        {
            Debugger.Instance.Log("[Mint ERC1155] Error", e.Message);
        }
    
}
}
