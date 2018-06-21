using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        //Ball speed
        public float speed = 30f;
        //Velocity of ball
        private Vector3 velocity;
        public int score = 0;
        public Text scoreText;
        public Ball currentBall;
        public Transform parent;
        public Paddle paddle;
        public GameObject ball;



        //Fires off ball in direction
        public void Fire(Vector3 direction)
        {
            //calculate velocity
            velocity = direction * speed;
        }

        //Detect collision
        void OnCollisionEnter2D(Collision2D other)
        {
            //Get contact points
            ContactPoint2D contact = other.contacts[0];
            //Calculate reflection point of the ball using velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            //Calculate new velocity from reflection multiplier by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
            if (other.gameObject.tag == "Brick")
            {
                Destroy(other.gameObject);
                score++;
                scoreText.text = "Score: " + score;
            }
            if (other.gameObject.tag == "Brick2")
            {
                Destroy(other.gameObject);
                score += 3;
                scoreText.text = "Score: " + score;
            }
            if (other.gameObject.tag == "Floor")
            {
                //Destroy(gameObject);
                paddle.ballInPlay = false;
                //Instantiate(ball, parent.transform);
                score -= 2;
                ball.transform.position = parent.transform.position;
                Time.timeScale = 1;
                speed = 0;

            }
            if (other.gameObject.tag == "Brick3")
            {
                Time.timeScale = 0.5f;
                Destroy(other.gameObject);
                score += 2;
                scoreText.text = "Score: " + score;
            }
            if (other.gameObject.tag == "Paddle")
            {
                Time.timeScale = 1;
            }
        }

        private void Start()
        {
            scoreText.text = "";
        }


        void Update()
        {
            //Moves ball using velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
            
            if(score < 25)
            {
                scoreText.text = "Score: " + score + " Thats meh";
            }
            if (score < 50 && score > 25)
            {
                scoreText.text = "Score: " + score + " Thats Mediocre";
            }
            if (score < 75 && score > 50)
            {
                scoreText.text = "Score: " + score + " Alright alright";
            }
            if (score < 100 && score > 75)
            {
                scoreText.text = "Score: " + score + " So close";
            }
        }


    }
}