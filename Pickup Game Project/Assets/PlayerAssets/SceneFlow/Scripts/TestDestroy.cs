using UnityEngine;

public class TestDestroy : MonoBehaviour
{
    public float destroyDelay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Update()
    {
        // Wait for the specified delay before destroying the gameobject
        Destroy(gameObject, destroyDelay);
    }
}
