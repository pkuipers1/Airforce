using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class InputParcer : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlsActions;
    
    [Header("Scripts")]
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private HealthData healthData;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlsActions = _playerInput.actions;
    }

    private void Start()
    {
        _playerControlsActions["DoDamge(Temp)"].performed += DoDamage;
    }

    private void FixedUpdate()
    {
        var moveInput = _playerControlsActions["Move"].ReadValue<Vector2>();
        playerMovement.MovePlayer(moveInput);
    }
    
    private void DoDamage(InputAction.CallbackContext context) => healthData.TakeDamage(5);
}
