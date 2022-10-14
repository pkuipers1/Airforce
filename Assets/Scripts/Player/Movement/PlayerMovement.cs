using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Child Objects")]
    [SerializeField] private GameObject visual;
    
    [Header("Stats")] 
    [SerializeField] private Vector2 movementSpeed;
    [SerializeField] private Vector2 rotationSpeed;
    [SerializeField] private Vector3 currentRotation;
    [SerializeField] private float rotationReturner = 0.88f;
    
    [SerializeField] private float rotationThreshold;
    
    [Header("Booleans")]
    [SerializeField] private bool isMoving;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 moveInput)
    {
        rb.velocity = new Vector2(moveInput.x * movementSpeed.x, moveInput.y * movementSpeed.y);
        RotatingPlayer(moveInput);
    }
    
    private void RotatingPlayer(Vector2 moveInput)
    {
        var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdZ = currentRotation.z < rotationThreshold && currentRotation.z > -rotationThreshold;
        
        if(rotationThresholdX && moveInput.y > 0) currentRotation.x -= rotationSpeed.x;
        else if(rotationThresholdX && moveInput.y < 0) currentRotation.x += rotationSpeed.x;

        if(rotationThresholdZ && moveInput.x > 0) currentRotation.z += rotationSpeed.y;
        else if(rotationThresholdZ && moveInput.x < 0) currentRotation.z -= rotationSpeed.y;
        
        if (!isMoving) currentRotation *= rotationReturner;

        var applyAbleRotation = new Vector3(currentRotation.x, currentRotation.z, 0);

        visual.transform.localEulerAngles = applyAbleRotation;
    }
}
