using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserEnemyScript : MonoBehaviour
{
    public SpriteRenderer sRenderer;

    public Vector2 moveDirection = new Vector2(2, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveDirection *= -1.0f;
        sRenderer.flipX = !sRenderer.flipX;
    }
}