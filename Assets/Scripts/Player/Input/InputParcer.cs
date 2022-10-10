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

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlsActions = _playerInput.actions;
        Debug.Log(_playerControlsActions);
    }

    private void FixedUpdate()
    {
        var moveInput = _playerControlsActions["Move"].ReadValue<Vector2>();
        playerMovement.MovePlayer(moveInput);
    }
}
