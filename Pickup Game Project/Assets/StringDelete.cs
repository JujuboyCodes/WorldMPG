using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ReadyPlayerMe
{
public class StringDelete : MonoBehaviour
{
  public TMP_Text UserUrl;
    public TMP_Text v1Url;
    public TMP_Text convertedUrl ;

  string myString = "Hello World!";
  public GameObject Canvas;
  private GameObject avatar;

void Start() {
    UserUrl.text = myString;

    //string oldUrl = PlayerPrefs.GetString("avatar_url","");
     string oldUrl = "https://models.readyplayer.me/63c45504e5b9a43558816c73.glb";
     string avatarUrl = oldUrl.Replace("models", "api").Replace(".me/", ".me/v1/avatars/");
      v1Url.text = oldUrl;
      convertedUrl.text = avatarUrl;

      if (avatarUrl == "")
        {
          Debug.Log("avatar_url not found in PlayerPrefs");
          Canvas.SetActive(false);
        }
        else
        {
          Debug.Log("avatar_url found in PlayerPrefs: " + avatarUrl);
        }
          var avatarLoader = new AvatarLoader();
          avatarLoader.OnCompleted += (_, args) =>
        {
         // avatar = args.Avatar;
           // AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
        };
          // avatarLoader.LoadAvatar(avatarUrl);
        }


    // Update is called once per frame
    void Update()
    {
        
    }
}
}