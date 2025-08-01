using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public KeyCode castKey = KeyCode.E; // Left click to cast

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
            Debug.Log("Fish hooked! Reeling in...");
            yield return new WaitForSeconds(2f); // simulate reeling in
            Debug.Log("You caught a fish!");
        }
        else
        {
            Debug.Log("Nothing bit... reel in an empty line.");
        }

        lineCast = false;
        isFishing = false;
    }
}
