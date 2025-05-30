using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class wallToWallScript : MonoBehaviour
{
    public SpriteRenderer sRenderer;

    public Vector2 move = new Vector2(-0.5f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(move.x, move.y) * Time.deltaTime;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        move *= -1.0f;
        sRenderer.flipX = !sRenderer.flipX;
    }
}
