using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondHandlerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GameManagementScipt.instance.diamondPickedUp();
            Debug.Log("Diamond collected!");
            Destroy(gameObject);
        }
    }
}
