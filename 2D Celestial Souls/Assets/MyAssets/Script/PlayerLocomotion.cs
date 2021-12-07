using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Script
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        private RaycastHit2D _hit;

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

            #region MovementLogic

            // Make sure we can move in this y direction, by casting there first, if the box return null we are free to move
            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, moveDelta.y),
                Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (_hit.collider == null)
            {
                // Character Movement y direction
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);    
            }
            
            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(moveDelta.x, 0),
                Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (_hit.collider == null)
            {
                // Character Movement x direction
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);    
            }

            #endregion
            
        }
    }   
}
