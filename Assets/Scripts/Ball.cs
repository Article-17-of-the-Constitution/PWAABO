using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    int score;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(x * speed, y * speed);
    }



    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="brick")
        {            
            Destroy(collision.gameObject);            
        }
        if (collision.gameObject.tag == "bottom")
        {
            GameManager.I.GameEnd();
        }
    }

}
