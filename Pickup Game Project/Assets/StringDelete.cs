using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ReadyPlayerMe
{
public class StringDelete : MonoBehaviour
{
  public TMP_Text UserUrl;
    public TMP_Text UserUrl1;
  string myString = "Hello World!";
  public GameObject Canvas;
  private GameObject avatar;

void Start() {
    UserUrl.text = myString;

    UserUrl1.text = PlayerPrefs.GetString("avatar_url", "");
     string avatarUrl = PlayerPrefs.GetString("avatar_url", "");
      
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
          avatar = args.Avatar;
          //  AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
        };
          avatarLoader.LoadAvatar(avatarUrl);
        }

       // private void OnDestroy()
        //{
           // if (avatar != null) Destroy(avatar);
     //   }    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
}