using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point"))
        {
            Destroy(collision.gameObject);
            GameManagementScipt.instance.pointPickedUp();
            Debug.Log("Point collected!");
        }

        if (collision.CompareTag("key"))
        {
            Debug.Log("Key collected!");
        }
        else
        {
            GameManagementScipt.instance.resetPlayer();
        }
    }
}
