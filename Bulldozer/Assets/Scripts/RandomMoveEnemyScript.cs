using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveEnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectonIteration = 4f;
    public float defaultRotation = 180f;
    public SpriteRenderer sRenderer;
    private Vector2 moveDirection;

    void Start()
    {
        StartCoroutine(RandomDirectionRoutine());
        PickRandomDirection();
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

        // Forgatás a mozgás irányába (Z-tengely körül)
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + defaultRotation);
        }
    }

    IEnumerator RandomDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectonIteration);
            PickRandomDirection();
        }
    }

    void PickRandomDirection()
    {
        // Random irány (unit circle bármely pontja, de nem (0,0))
        moveDirection = Random.insideUnitCircle.normalized;
        // Itt beállíthatod, hogy mindig csak bizonyos irányokba mehessen (pl. csak vízszintes/függõleges)
        // moveDirection = Random.value > 0.5f ? Vector2.right : Vector2.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Visszapattanás – egyszerûen megfordítja az irányt
        moveDirection *= -1.0f;

        // Alternatíva: csak az adott tengelyen tükröz
        // var normal = (transform.position - collision.transform.position).normalized;
        // moveDirection = Vector2.Reflect(moveDirection, normal);

        // Sprite „flip”-elése helyett most forgatással oldjuk meg, de ha oldalnézetes a sprite-od:
        // sRenderer.flipX = moveDirection.x < 0;
    }
}
