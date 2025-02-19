using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float jumpPower = 6f;
    public bool isGrounded;
    float posX = 0.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        Time.timeScale = 1;

    }
    void GameOver()
    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower * rb.mass * rb.gravityScale * 20f);

        }
        if (transform.position.x < posX)
        {
            GameOver();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameOver();
        }
    }
    private void OnCollisionTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
    }
  


}