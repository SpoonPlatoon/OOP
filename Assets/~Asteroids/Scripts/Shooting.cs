using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;

        public float shootTimer = 0f;

        public Transform spawnPoint;

        void Shoot()
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            rigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
      
        void Update()
        {
            //SET shootTimer = shootTimer + deltaTime
            shootTimer += Time.deltaTime;
            //IF shootTimer >= shootRate
            if (shootTimer >= shootRate)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //Call Shoot()
                    Shoot();
                    //SET shootTimer = 0
                    shootTimer = 0f;
                }
            }
        }
    }
}