using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered shop area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left shop area");
        }
    }

    private void OpenShop()
    {
        //shop UI  logic here
        Debug.Log("Shop opened!");

        //// Find the player
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //if (player != null)
        //{

        //    Boat boatScript = player.GetComponent<Player>();
        //    if (boatScript != null)
        //    {
        //        boatScript.enabled = false;
        //    }
        //}
    }
}
