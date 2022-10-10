using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player do the move
    private Rigidbody2D rb;

    [Header("Stats")] 
    [SerializeField] private Vector2 movementSpeed;
    
    [Header("Booleans")]
    [SerializeField] private bool isMoving;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 moveInput)
    {
        rb.velocity = new Vector2(moveInput.x * movementSpeed.x, moveInput.y * movementSpeed.y);
        Debug.Log(rb.velocity);
    }
}
