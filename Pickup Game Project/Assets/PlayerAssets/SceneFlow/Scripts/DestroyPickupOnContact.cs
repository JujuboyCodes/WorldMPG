using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickupOnContact : MonoBehaviour
{
   // public string pickupTag = "PickUp"; // The tag for the pickup items

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
    
            // Destroy the other game object
            Destroy(gameObject);
        
    }
}
