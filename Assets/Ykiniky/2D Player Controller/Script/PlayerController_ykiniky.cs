using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YkinikY
{
    public class PlayerController_ykiniky : MonoBehaviour
    {
        [Header("(c) Ykiniky")]
        [Header("Movement")]
        public bool canMove = true;
        public bool canJump = true;
        public float velocity = 1;
        
        public Vector2 lastCheckpoint;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            MovimentUpdate();
            
        }
        public void GameOver()
        {
            canMove = false;
        }
        void MovimentUpdate()
        {
            float moveInput=Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += 5 * Time.deltaTime * velocity * Vector3.left;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += 5 * Time.deltaTime * velocity * Vector3.right;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if ((Input.GetKey(KeyCode.Space) & canJump) || (Input.GetKey(KeyCode.W) & canJump))
            {
                canJump = false;
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 6);
            }
            // Contoller definitions
            if (Input.GetButton("Jump") && canJump)
            {
                canJump = false;
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 6);
            }
            transform.position += 5 * Time.deltaTime * velocity * Vector3.right * Input.GetAxis("Horizontal");
            if (Input.GetAxis("Horizontal") == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetAxis("Horizontal") == -1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (moveInput > 0.01f)
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
 

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            canJump = true;
            if (collision.gameObject.name == "PlayerSlower")
            {
                BecomeSlow();
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.name == "PlayerSlower")
            {
                BecomeNormal();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.name == "Elevator")
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 6);
            }
            if (collision.name == "Down_elevator")
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, -4);
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Nastro trasportatore s")
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-20, GetComponent<Rigidbody2D>().linearVelocity.y));
            }
            if (collision.gameObject.name == "Nastro trasportatore d")
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(20, GetComponent<Rigidbody2D>().linearVelocity.y));
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Checkpoint")
            {
                lastCheckpoint = transform.position;
            }
        }
        public void TeleportPlayerX(float playerX)
        {
            transform.position = new Vector2(playerX, transform.position.y);
        }
        public void TeleportPlayerY(float playerY)
        {
            transform.position = new Vector2(transform.position.x, playerY);
        }
        public void BecomeSlow()
        {
            velocity = 0.37f;
        }
        public void BecomeNormal()
        {
            velocity = 1f;
        }
    }
}
