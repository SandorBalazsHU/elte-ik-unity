using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float moveSpeed = 4f;

    public Transform cameraTransform;

    private bool isGameover = false;

    public void gameOver()
    {
        isGameover = true;
        StartCoroutine(gameOverColoring());
    }

    IEnumerator gameOverColoring()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(0.4f);
        rend.color = Color.red;
    }

    void FixedUpdate()
    {
        if (!isGameover)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontal, vertical);

            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            if (horizontal > 0.01f)
                transform.rotation = Quaternion.Euler(0f, 0f, 270f); // Right
            else if (horizontal < -0.01f)
                transform.rotation = Quaternion.Euler(0f, 0f, 90f); // Left

            if (vertical > 0.01f)
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Up
            else if (vertical < -0.01f)
                transform.rotation = Quaternion.Euler(0f, 0f, 180f); // Down

            //Camera rotation reset.
            cameraTransform.rotation = Quaternion.identity;
        }
    }
};