using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveUserPrefs : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField avatarurlinput;
    public GameObject UrLWarning;

    private const string PREFS_NAME = "NameInput";
    private const string PREFS_AVATAR_URL = "Avatarurlinput";

    void Start()
    {
        // Load saved preferences
        if (PlayerPrefs.HasKey(PREFS_NAME))
        {
            nameInput.text = PlayerPrefs.GetString(PREFS_NAME);
        }

        if (PlayerPrefs.HasKey(PREFS_AVATAR_URL))
        {
            avatarurlinput.text = PlayerPrefs.GetString(PREFS_AVATAR_URL);
        }
    }

   public void SaveInputsToPrefs()
   {
    // Check if the avatar URL input contains ".glb"
    if (avatarurlinput.text.Contains(".glb"))
    {
        // Save input fields to preferences
        PlayerPrefs.SetString(PREFS_NAME, nameInput.text);
        PlayerPrefs.SetString(PREFS_AVATAR_URL, avatarurlinput.text);
        PlayerPrefs.Save();

        // Print Saved Values
        Debug.Log("Successfully " + PREFS_NAME + " contains: " + PlayerPrefs.GetString(PREFS_NAME));
        Debug.Log("Prefs " + PREFS_AVATAR_URL + " contains: " + PlayerPrefs.GetString(PREFS_AVATAR_URL));

        // Switch to the "connectwalletscene" scene
        SceneManager.LoadScene("ConnectWalletScene");
    }
    else
    {
        UrLWarning.SetActive(true);

        // Display an error message if the avatar URL input doesn't contain ".glb"
        Debug.Log("Avatar URL input must contain '.glb'");
          StartCoroutine(ResetUrlWarning());
    }

   
    }

    private IEnumerator ResetUrlWarning()
    {
    yield return new WaitForSeconds(2f);
    UrLWarning.SetActive(false);
    }

}



