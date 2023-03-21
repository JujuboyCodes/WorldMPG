using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace ReadyPlayerMe
{
    public class WebViewExample : MonoBehaviour
    {
         private GameObject avatar;

        [SerializeField] private WebView webView;
        [SerializeField] private GameObject loadingLabel;
        [SerializeField] private Button displayButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button switchscene;

        [SerializeField,
         Tooltip("Uncheck if you don't want to continue editing the previous avatar, and make a completely new one.")]
        private bool keepBrowserSessionAlive = true;

        private void Start()
        {
            DisplayWebView();  // Displays RPM Webview immwdiately OnStart
            switchscene.onClick.AddListener(GoToRuntime);
            displayButton.onClick.AddListener(DisplayWebView);
            closeButton.onClick.AddListener(HideWebView);
            if (webView == null)
            {
                webView = FindObjectOfType<WebView>();
            }

            webView.KeepSessionAlive = keepBrowserSessionAlive;
        }

        // Display WebView or create it if not initialized yet 
        private void DisplayWebView()
        {
            if (webView.Loaded)
            {
                webView.SetVisible(true);
            }
            else
            {
                webView.CreateWebView();
                webView.OnAvatarCreated = OnAvatarCreated;
            }

            closeButton.gameObject.SetActive(true);
            displayButton.gameObject.SetActive(false);
        }

        private void HideWebView()
        {
            webView.SetVisible(false);
            closeButton.gameObject.SetActive(false);
            displayButton.gameObject.SetActive(true);
        }

        // WebView callback for retrieving avatar url
        private void OnAvatarCreated(string url)
        {
            if (avatar) Destroy(avatar);
            webView.SetVisible(false);

            // save url to playerprefs
            PlayerPrefs.SetString("avatar_url", url);
            PlayerPrefs.Save();
            
            
            //Switch Back to HomeScreen Once is Created
            SceneManager.LoadScene("HomeScene");


        
           // loadingLabel.SetActive(true);
           //displayButton.gameObject.SetActive(false);
           //closeButton.gameObject.SetActive(false);

          

            // remove avatar loading-------------------
            //var avatarLoader = new AvatarLoader();
            //avatarLoader.OnCompleted += Completed;
            //avatarLoader.OnFailed += Failed;
            //avatarLoader.LoadAvatar(url);
            // stop deleting when you reach here-------

          
        }


        private void Failed(object sender, FailureEventArgs args)
        {
            Debug.LogError(args.Type);
        }

        // delete this as well if you dont want avatar to load into scene ----------------
        // AvatarLoader callback for retrieving loaded avatar game object
        private void Completed(object sender, CompletionEventArgs args)
        {
            avatar = args.Avatar;
            AvatarAnimatorHelper.SetupAnimator(args.Metadata.BodyType, avatar);
            loadingLabel.SetActive(false);
            displayButton.gameObject.SetActive(true);

            Debug.Log("Avatar Imported");
        }
        // stop deleting when you reach this point ----------------------------------------


        private void OnDestroy()
        {
            displayButton.onClick.RemoveListener(DisplayWebView);
            closeButton.onClick.RemoveListener(HideWebView);

            if (avatar) Destroy(avatar);
        }

        private void GoToRuntime()
    {
        SceneManager.LoadScene(1);
    }
    }
}
