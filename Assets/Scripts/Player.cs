using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private int direction = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Enable();
        
        Event.drawDistance = mainCamera.orthographicSize * mainCamera.aspect / 2;
    }

    private void Update()
    {
        if (controls.Player.Turn.triggered)
        {
            ChangeDirection();
        }
        Move();

    }

    private void Stay()
    {
        animator.SetBool("Run", false);
        Event.speed = 0;
    }

    private void Move()
    {
        animator.SetBool("Run", true);
        Event.speed = speed * direction * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        direction *= -1;
        transform.localScale = new(direction, transform.localScale.y);
    }


}
