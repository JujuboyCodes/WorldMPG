using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe;
using UnityEngine.UI;

public class AvatarRender : MonoBehaviour
{
    #region Avatar Renderer
        [Header("Avatar Renderer UI")]
        [Space]
        [Tooltip("Avatar Renderer Settings")]
        public bool usingAvatarUI;
        [SerializeField] private AvatarRenderScene scene = AvatarRenderScene.FullBodyPostureTransparent;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private Image avatarUIPanel;
        
        public string avatarUrls;
        private const string TAG = nameof(AvatarRenderExample);
        private readonly string blendShapeMesh = "Wolf3D_Avatar";
        private readonly Dictionary<string, float> blendShapes = new Dictionary<string, float>
        {
            { "mouthSmile", 0.7f },
            { "viseme_aa", 0.5f },
            { "jawOpen", 0.3f }
        };


    // Start is called before the first frame update
    void Start()
    {
        avatarUrls = PlayerPrefs.GetString("avatar_url");

        StartLoadAvatarRenderer(avatarUrls);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     #region Avatar Renderer
        private void StartLoadAvatarRenderer(string _loadAvatarRenderer)
        {
            var avatarRenderer = new AvatarRenderLoader
            {
                OnCompleted = UpdateSprite,
                OnFailed = Fail
            };
            avatarRenderer.LoadRender(_loadAvatarRenderer, scene, blendShapeMesh, blendShapes);
            loadingPanel.SetActive(true);

            SDKLogger.Log(TAG, "Start Load Avatar Renderer");
        }
        private void UpdateSprite(Texture2D render)
        {
            var sprite = Sprite.Create(render, new Rect(0, 0, render.width, render.height), new Vector2(.5f, .5f));
            spriteRenderer.sprite = sprite;
            loadingPanel.SetActive(false);

            if(sprite != null)
            {
                AssignThumbnail(spriteRenderer, sprite);
            }

            SDKLogger.Log(TAG, "Sprite Updated ");
        }
        private void Fail(FailureType type, string message)
        {
            SDKLogger.Log(TAG, $"Failed with error type: {type} and message: {message}");
        }
        private void AssignThumbnail(SpriteRenderer spriteRenderer, Sprite sprite)
        {
            avatarUIPanel.gameObject.SetActive(true);
            bool avatarUIPanelActive = avatarUIPanel.IsActive();

            if (sprite && avatarUIPanelActive)
            {
                avatarUIPanel.sprite = sprite;
                avatarUIPanel.material.mainTexture = spriteRenderer.sharedMaterial.mainTexture;
                // Set the alpha of the avatarUIPanel's color to 255 (fully opaque)
                Color panelColor = avatarUIPanel.color;
                panelColor.a = 1f;
                avatarUIPanel.color = panelColor;

                spriteRenderer.gameObject.SetActive(false);
            }
        }
        #endregion
}

#endregion