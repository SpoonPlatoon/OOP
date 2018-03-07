using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        public Moving movement;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float inputV = Input.GetAxis("Vertical");
            float inputH = Input.GetAxis("Horizontal");
            // -1 == A || LeftArrow
            //  0 == Not Pressed
            //  1 == D || RightArrow

            if (inputV > 0)
            {
                movement.Accelerate(transform.up);
            }

            if (inputH < 0 )
            {
                movement.RotateLeft();
            }

            if (inputH > 0)
            {
                movement.RotateRight();
            }
        }
    }
}