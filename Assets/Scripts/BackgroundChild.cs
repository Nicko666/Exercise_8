using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChild : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private GameObject left;
    private GameObject right;
    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        float size = spriteRenderer.bounds.size.x;

        if (right == null)
        {
            if (transform.position.x < Event.drawDistance + size)
            {
                Vector3 newPosition = new Vector3(transform.position.x + size, transform.position.y);
                right = Instantiate(gameObject, newPosition, new Quaternion(), transform.parent.transform);
                right.GetComponent<BackgroundChild>().left = gameObject;
            }
        }
        if (left == null)
        {
            if (transform.position.x > -Event.drawDistance - size)
            {
                Vector3 newPosition = new Vector3(transform.position.x - size, transform.position.y);
                left = Instantiate(gameObject, newPosition, new Quaternion(), transform.parent.transform);
                left.GetComponent<BackgroundChild>().right = gameObject;
            }
        }
    }
}
