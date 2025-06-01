using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DispenserHandlerScript : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector2 fireDirection = new Vector2(0, -2);

    public float fireInterval = 2f;

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        GameObject newProjectile = Instantiate(
        projectilePrefab,
        transform.position + new Vector3(fireDirection.normalized.x, fireDirection.normalized.y),
        Quaternion.identity
        );

        var projScript = newProjectile.GetComponent<ProjectileHandlerScript>();
        if (projScript != null)
        {
            projScript.moveDirection = fireDirection;
        }
    }
}
