using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroud : MonoBehaviour
{
    [SerializeField] private float paralaxSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameObject left;
    private GameObject right;
    private float size;

    private void Start()
    {
        size = spriteRenderer.sprite.bounds.size.x;
    }

    private void Update()
    {
        Move();
        Draw();
        Erase();
    }
    private void Move()
    {
        transform.position -= new Vector3(Event.speed * paralaxSpeed, 0);
    }

    private void Draw()
    {
        if (right == null)
        {
            if (transform.position.x < Event.drawDistance)
            {
                Vector3 newPosition = new Vector3(transform.position.x + size, transform.position.y);
                right = Instantiate(gameObject, newPosition, new Quaternion());
                right.GetComponent<Backgroud>().left = gameObject;
            }
        }
        if (left == null)
        {
            if (transform.position.x > -Event.drawDistance)
            {
                Vector3 newPosition = new Vector3(transform.position.x - size, transform.position.y);
                left = Instantiate(gameObject, newPosition, new Quaternion());
                left.GetComponent<Backgroud>().right = gameObject;
            }
        }

    }

    private void Erase()
    {
        if(transform.position.x > Event.drawDistance + size)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -Event.drawDistance - size)
        {
            Destroy(gameObject);
        }
    }
}
