using System.Collections;
using System.Collections.Generic;
using ReadyPlayerMe;
using UnityEngine;

public class RpmEnabler : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableScriptAfterDelay());
    
        IEnumerator EnableScriptAfterDelay() {
        yield return new WaitForSeconds(1);
        var script = Player.GetComponent<RPMRuntime>();
        script.enabled = true;

    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
