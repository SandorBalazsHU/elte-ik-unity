using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandlerScript : MonoBehaviour
{
    public Vector2 moveDirection = new Vector2(0, 2);

    private SpriteRenderer sRenderer;
    private bool isDestroying = false;
    private float redFlashTime = 0.3f;

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDestroying)
            StartCoroutine(DestroyAfterRed());
    }

    IEnumerator DestroyAfterRed()
    {
        isDestroying = true;
        moveDirection = new Vector2(0, 0);
        if (sRenderer != null)
            sRenderer.color = Color.red;
        yield return new WaitForSeconds(redFlashTime);
        Debug.Log("Projectal destroyed!");
        Destroy(gameObject);
    }
}