using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private void OnDestroy()
    {
        gameManagementScipt.instance.spawnPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
            //Méhecske törlése
            //Destroy(collision.gameObject);
        }
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            gameManagementScipt.instance.coinPickedUp();
            //Méhecske törlése
            //Destroy(collision.gameObject);
        }
    }
}
