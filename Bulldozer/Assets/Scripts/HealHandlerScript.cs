using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHandlerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        { 
            GameManagementScipt.instance.healPickedUp();
            Debug.Log("Heal collected!");
            Destroy(gameObject);
        }
    }
}
