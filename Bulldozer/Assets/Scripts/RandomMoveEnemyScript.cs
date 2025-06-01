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

        // Forgat�s a mozg�s ir�ny�ba (Z-tengely k�r�l)
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
        // Random ir�ny (unit circle b�rmely pontja, de nem (0,0))
        moveDirection = Random.insideUnitCircle.normalized;
        // Itt be�ll�thatod, hogy mindig csak bizonyos ir�nyokba mehessen (pl. csak v�zszintes/f�gg�leges)
        // moveDirection = Random.value > 0.5f ? Vector2.right : Vector2.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Visszapattan�s � egyszer�en megford�tja az ir�nyt
        moveDirection *= -1.0f;

        // Alternat�va: csak az adott tengelyen t�kr�z
        // var normal = (transform.position - collision.transform.position).normalized;
        // moveDirection = Vector2.Reflect(moveDirection, normal);

        // Sprite �flip�-el�se helyett most forgat�ssal oldjuk meg, de ha oldaln�zetes a sprite-od:
        // sRenderer.flipX = moveDirection.x < 0;
    }
}
