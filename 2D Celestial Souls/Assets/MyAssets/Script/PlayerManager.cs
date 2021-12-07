using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Script
{
    public class PlayerManager : MonoBehaviour
    {
        public InputHandler inputHandler;
        public PlayerLocomotion playerLocomotion;
        private void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        private void FixedUpdate()
        {
            playerLocomotion.Locomotion();
        }
    }
}