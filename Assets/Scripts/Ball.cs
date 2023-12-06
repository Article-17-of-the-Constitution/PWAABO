using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    public AudioClip DM_CGS_44;
    public AudioSource audioSource;


    public float ballspeed = 10f;

    private Vector2 balldirection;
    private bool isballreleased = false;
    
    void Start()
    {
        balldirection = Vector2.up.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isballreleased)
        {
            Vector3 paddleposition = GameObject.Find("Paddle").transform.position;

            Vector3 ballposition = paddleposition;
            ballposition.y += 0.2f;
            transform.position = ballposition;

            if (Input.GetButtonDown("Fire1"))
            {
                isballreleased = true;
                balldirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
            }

        }
        else
        {
            transform.Translate(balldirection * ballspeed * Time.deltaTime);
        }
    }



    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "brick")
        {
            audioSource.PlayOneShot(DM_CGS_44);
            Destroy(collision.gameObject);
            balldirection = Vector2.Reflect(balldirection, collision.contacts[0].normal);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            balldirection = Vector2.Reflect(balldirection, collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitpoint = collision.contacts[0].point.x;
            float paddlecenter = collision.transform.position.x;
            float angle = (hitpoint - paddlecenter) * 2.0f;
            balldirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(DM_CGS_44);
            GameManager.I.GameEnd();
        }

    }
}
