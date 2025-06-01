using System.Collections;
using UnityEngine;

//Azt olvastam, hogyha a rigid body-n keresztül mozgatom, akkor nem fog átbug-olni a falakon. Bejött.
[RequireComponent(typeof(Rigidbody2D))]
public class RandomMoveEnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionInterval = 4f;
    public float defaultRotation = 180f;
    public SpriteRenderer sRenderer;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;
    }

    void Start()
    {
        StartCoroutine(RandomDirectionRoutine());
        PickRandomDirection();
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;

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
            yield return new WaitForSeconds(changeDirectionInterval);
            PickRandomDirection();
        }
    }

    void PickRandomDirection()
    {
        //A doksiban találtam, random irányokhoz.
        moveDirection = Random.insideUnitCircle.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveDirection *= -1.0f;
    }
}
