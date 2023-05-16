using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Thirdweb;

public class HomeController : MonoBehaviour
{


  [SerializeField] private PlayerData playerData;
  [SerializeField] private GameObject PauseSettings;

  private CurrencyValue balance;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CustomizeAvatar()
    {
      SceneManager.LoadScene("RpmWebViewScene");
    }

    public void EnterGame()
    {
      // Resetting Player Score to Zero
      playerData.Playerscore = 0;

      // Load Game Scene
      SceneManager.LoadScene("PickupGameScene");

     
    }

     public void BackButton()
    {
      SceneManager.LoadScene("ConnectWalletScene");
    }

      public void OpenSettings()
    {
      PauseSettings.SetActive(true);
    }
    
      public void CloseSettings()
    {
      PauseSettings.SetActive(false);
    }

       public async void GetBalance()
    {
      Debug.Log("Cant find Balance");
        try
        {
          balance = await ThirdwebManager.Instance.SDK.wallet.GetBalance();
          Debugger.Instance.Log("[Get Balance] Native Balance", balance.ToString());
            
        
        }
        catch (System.Exception e)
        {
          Debugger.Instance.Log("[Get Balance] Error", e.Message);
          
        }
    }

}
