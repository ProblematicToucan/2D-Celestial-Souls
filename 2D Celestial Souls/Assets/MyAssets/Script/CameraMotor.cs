using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Script
{
    public class CameraMotor : MonoBehaviour
    {
        public Transform lookAt;
        public float boundX = .15f;
        public float boundY = .05f;

        private void LateUpdate()
        {
            var delta = Vector3.zero;

            // Check if we're inside the bounds on the x axis
            var deltaX = lookAt.position.x - transform.position.x;
            if (deltaX > boundX || deltaX < -boundX)
            {
                if (transform.position.x < lookAt.position.x)
                {
                    delta.x = deltaX - boundX;
                }
                else
                {
                    delta.x = deltaX + boundX;
                }
                
            }
            
            // Check if we're inside the bounds on the y axis
            var deltaY = lookAt.position.y - transform.position.y;
            if (deltaY > boundY || deltaY < -boundY)
            {
                if (transform.position.y < lookAt.position.y)
                {
                    delta.y = deltaY - boundY;
                }
                else
                {
                    delta.y = deltaY + boundY;
                }
            }

            transform.position += new Vector3(delta.x, delta.y, 0);
        }
    }
}
