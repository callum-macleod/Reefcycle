using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public KeyCode castKey = KeyCode.E; 
    public int caughtFish;
    public int maxFish = 10;

    [Header("Fishing Settings")]
    public float minBiteTime = 2f;
    public float maxBiteTime = 5f;
    [Range(0f, 1f)] public float hookChance = 0.7f;

    private bool isFishing = false;
    private bool lineCast = false;

    void Update()
    {
        if (!isFishing && Input.GetKeyDown(castKey))
        {
            StartCoroutine(FishingRoutine());
        }
    }

    IEnumerator FishingRoutine()
    {
        isFishing = true;
        lineCast = true;

        Debug.Log("Casting line...");

        // Wait for random bite time
        float waitTime = Random.Range(minBiteTime, maxBiteTime);
        yield return new WaitForSeconds(waitTime);

        // Simulate fish bite
        bool fishBite = Random.value <= hookChance;

        if (fishBite)
        {
            if(caughtFish <= maxFish)
            {
                Debug.Log("Fish hooked! Reeling in...");
                yield return new WaitForSeconds(2f); // simulate reeling in
                caughtFish++;
                Debug.Log("You caught a fish! you have " + caughtFish + "/" + (maxFish+1) + " fish");
            }
            else
            {
                Debug.Log("you have caugh " + (maxFish +1) + " return to hub to sell");
            }
               
        }
        else
        {
            Debug.Log("Nothing bit... reel in an empty line.");
        }

        lineCast = false;
        isFishing = false;
    }
}
