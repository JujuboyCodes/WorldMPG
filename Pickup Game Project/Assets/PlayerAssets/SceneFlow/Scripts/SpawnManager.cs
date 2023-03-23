using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints1; // An array of spawn points
     public Transform[] spawnPoints2; // An array of spawn points
    public GameObject itemPrefab; // The item that we want to spawn
    public float respawnDelay = 2.0f; // The delay between respawning items
    public string pickupTag = "PickUp"; // The tag for the pickup items

    private bool allItemsDestroyed = false; // Whether all items have been destroyed

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllItems();
    }

    // Update is called once per frame
    void Update()
    {

           if (GameObject.FindGameObjectWithTag(pickupTag) != null)
            {
               // Debug.Log("Found PickUp Something");
            }
        // If all items have been destroyed, start respawning them
        if (GameObject.FindGameObjectWithTag(pickupTag) == null)
        {
           // Debug.Log("All PickUps Used");
            StartCoroutine(RespawnItems());
        }
    }

    // Spawn all items at the start of the game
    void SpawnAllItems()
    {
        for (int i = 0; i < spawnPoints1.Length; i++)
        {
            SpawnItem(spawnPoints1[i]);
        }
    }

    // Spawn an item at the given spawn point
    void SpawnItem(Transform spawnPoint)
    {
        Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Coroutine to respawn all items after a delay
    IEnumerator RespawnItems()
    {
             int currentSpawnIndex = 0;
            
            yield return new WaitForSeconds(respawnDelay);
 

            // Check if any game object with the pickupTag exists
            if (GameObject.FindGameObjectWithTag(pickupTag) == null)
            {
                
                // Respawn all items
                for (int i = 0; i < spawnPoints2.Length; i++)
                {
                    SpawnItem(spawnPoints2[currentSpawnIndex]);
                    currentSpawnIndex = (currentSpawnIndex + 1) % spawnPoints2.Length;

                    
                }
            }

            yield return new WaitForSeconds(respawnDelay);

        
    }

    // Check if all items have been destroyed
    void CheckAllItemsDestroyed()
    {
        // Check if any game object with the pickupTag exists
        if (GameObject.FindGameObjectWithTag(pickupTag) == null)
        {
            allItemsDestroyed = true;
        }
    }

    // Callback function to handle item destruction
    public void OnItemDestroyed()
    {
        // Check if all items have been destroyed
        CheckAllItemsDestroyed();

        // If all items have been destroyed, start respawning them
        if (allItemsDestroyed)
        {
            StartCoroutine(RespawnItems());
        }
    }
}
