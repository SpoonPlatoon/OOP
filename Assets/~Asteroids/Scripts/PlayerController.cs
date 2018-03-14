using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        public Moving movement;
        public Shooting shoot;

        #region Unity Functions
        void Start()
        {

        }

        void Update()
        {
            Shoot();
            Movement();
        }
        #endregion

        #region Custom Functions
        void Shoot()
        {
            // Check if space is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Fire!
                shoot.Fire(transform.up);
            }
        }
        void Movement()
        {
             float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
            // -1 == A || LeftArrow
            //  0 == Not Pressed
            //  1 == D || RightArrow

            if (inputV > 0)
            {
                movement.Accelerate(transform.up);
            }

            if (inputH< 0 )
            {
                movement.RotateLeft();
            }

            if (inputH > 0)
            {
                movement.RotateRight();
            }

            if(Input.GetKey(KeyCode.S))
            {
                movement.Stop();
            }
        }

     
        #endregion
    }
}