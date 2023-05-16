using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("MusicSource" ).Length > 1)
        {
          Destroy(gameObject);
        }
        else
        {
           DontDestroyOnLoad(gameObject);
        }
        
         if(GameObject.FindGameObjectsWithTag("SoundfxSource").Length > 1)
        {
          Destroy(gameObject);
        }
        else
        {
           DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
