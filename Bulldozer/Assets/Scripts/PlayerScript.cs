using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool canTakeDamage = true;
    public float invulnDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point"))
        {
            Destroy(collision.gameObject);
            GameManagementScipt.instance.pointPickedUp();
            Debug.Log("Point collected!");
        }

        if (collision.CompareTag("enemy") && canTakeDamage)
        {
            StartCoroutine(DamageFeedback());
            GameManagementScipt.instance.resetPlayer();
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator DamageFeedback()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        rend.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        rend.color = Color.white;
    }

    IEnumerator Invulnerability()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnDuration);
        canTakeDamage = true;
    }
}

