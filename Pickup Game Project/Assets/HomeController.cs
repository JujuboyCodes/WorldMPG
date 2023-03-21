using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeController : MonoBehaviour
{
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
      SceneManager.LoadScene("PickupGameScene");
    }

     public void BackButton()
    {
      SceneManager.LoadScene("ConnectWalletScene");
    }
}
