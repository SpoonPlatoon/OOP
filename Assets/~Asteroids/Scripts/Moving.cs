using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Moving : MonoBehaviour
    {
        public float acceleration = 5f;
        public float rotationSpeed = 3f;
        public float maxVelocity = 5f;

        Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            LimitVelocity();
        }
        void LimitVelocity()
        {
            // Copy Velocity inside smaller variable
            Vector3 vel = rigid.velocity;
            //Check if velocity reaches greater than maxVelocity
            if (vel.magnitude > maxVelocity)
            {
                //cap the velocity
                vel = vel.normalized * maxVelocity;
            }
            //apply the new velocity
            rigid.velocity = vel;
        }
        //Accelerates the player in a given direction
        public void Accelerate(Vector3 direction)
        {
            rigid.AddForce(direction * acceleration);
        }


        // public void Rotate(float Rotation)
        // {
        //    rigid.rotation += Rotation * rotationSpeed * Time.deltaTime;
        // }

        public void RotateLeft()
        {
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }

        public void RotateRight()
        {
            rigid.rotation += -rotationSpeed * Time.deltaTime;
        }

        public void Stop()
        {
            if (Input.GetKey(KeyCode.S))
            {
                rigid.velocity = Vector3.zero;
            }
        }
    }
}
