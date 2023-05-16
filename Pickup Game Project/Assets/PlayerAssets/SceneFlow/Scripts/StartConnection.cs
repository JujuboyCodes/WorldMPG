using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartConnection : MonoBehaviour
{
      public GameObject WelcomeMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemovewelcomeMessage();
    }

    public void SwitchToConnectedState(GameObject ConnectedState, GameObject DisConnectedState)
    {
      ConnectedState.SetActive(true);
      DisConnectedState.SetActive(false);
    }

    public void SwitchToDisconnectedState(GameObject ConnectedState, GameObject DisConnectedState)
    {
        ConnectedState.SetActive(false);
        DisConnectedState.SetActive(true);   

    }
    
    // This public function can be called from another script
    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAfterDelay("HomeScene"));
    }

    // This is a coroutine that waits for 1 second and then loads the specified scene
    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void RemovewelcomeMessage() // Starts coroutine to remove welcome message
    {
        StartCoroutine(RemoveMessage());
    }

    // This is a coroutine that waits for 2 second before removing Welcome message
    private IEnumerator RemoveMessage()
    {
        yield return new WaitForSeconds(2);
        WelcomeMessage.SetActive(false);
    }

    public void CheckTokenBalance()
    {
        
    }
}

