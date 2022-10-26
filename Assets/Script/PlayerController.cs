using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    
    /*
    [Min(0f)] [SerializeField] private float moveSpeed = 2.5f
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        UpdateMovementAxis();
    }
    private void FixedUpdate()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        var positionMovement = transform.forward * (movementAxis.y * moveSpeed * Time.deltaTime);
        var currentPosition = rb.position;
        var newPosition = currentPosition + positionMovement;
        rb.MovePosition(newPosition);
    }
    */public float moveSpeed = 0.2f;
    Animator animator;
    float movex;
    float movey;
    private Vector2 direction = new Vector2(0,-1);
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 move = new Vector2(movex, movey);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
                {
                    direction.Set(move.x, move.y);
                    direction.Normalize();
                }
                
                animator.SetFloat("Move X", direction.x);
                animator.SetFloat("Move Y", direction.y);
                animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(movex, movey);
        
        
        transform.Translate(movement * moveSpeed);
    }
}
