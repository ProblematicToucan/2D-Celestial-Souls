using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GD.Script
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerControls _playerControls;
        public Vector2 moveDelta;

        private void Awake()
        {
            _playerControls ??= new PlayerControls();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
            
            // Unsubscribe Event
            _playerControls.PlayerMovement.Movement.performed -= Movement;
        }

        private void Start()
        {
            // Subscribe Event
            _playerControls.PlayerMovement.Movement.performed += Movement;
        }

        // Event
        private void Movement(InputAction.CallbackContext context)
        {
            moveDelta = context.ReadValue<Vector2>();
        }
    }
}
