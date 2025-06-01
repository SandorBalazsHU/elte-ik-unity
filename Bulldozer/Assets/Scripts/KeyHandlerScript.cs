using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KeyHandlerScript : MonoBehaviour
{
    public List<GameObject> walls = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            foreach (var wall in walls)
            {
                Destroy(wall);
            }
            Debug.Log("Key collected! Walls destroyed!");
            Destroy(this);
        }
    }
}
