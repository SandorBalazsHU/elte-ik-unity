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

        if (collision.CompareTag("enemy"))
        {
            StartCoroutine(DamageFeedback());
            GameManagementScipt.instance.resetPlayer();
        }
    }

    IEnumerator DamageFeedback()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        rend.color = Color.red;
        yield return new WaitForSeconds(0.3f);

        rend.color = Color.white;
    }
}
