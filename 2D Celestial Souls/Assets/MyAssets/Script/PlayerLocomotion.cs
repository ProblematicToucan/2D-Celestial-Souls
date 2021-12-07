using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Script
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;

        private PlayerManager _playerManager;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _playerManager = GetComponent<PlayerManager>();
        }

        public void Locomotion()
        {
            var moveDelta = _playerManager.inputHandler.moveDelta;
            
            // Character Direction
            if (moveDelta.x > 0)
                transform.localScale = Vector3.one;
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            
            // Character Movement
            transform.Translate(moveDelta * Time.deltaTime);
        }
    }   
}
