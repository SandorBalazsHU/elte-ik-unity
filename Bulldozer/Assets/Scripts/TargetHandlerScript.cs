using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandlerScript : MonoBehaviour
{
    public Sprite stonePlacedSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("stone"))
        {
            Destroy(collision.gameObject);
            GameManagementScipt.instance.stonePickedUp();
            GetComponent<SpriteRenderer>().sprite = stonePlacedSprite;
            Debug.Log("Stone collected!");
        }
    }
}
