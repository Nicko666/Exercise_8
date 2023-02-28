using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundParent : MonoBehaviour
{
    [SerializeField] private float paralaxSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float size;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        }

        size = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position -= new Vector3(Event.speed * paralaxSpeed, 0);

        if (transform.position.x < -size / 2)
        {
            transform.position += Vector3.right * size;
        }
        if (transform.position.x > size / 2)
        {
            transform.position += Vector3.left * size;
        }
    }
}
