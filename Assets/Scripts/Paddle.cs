using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    float x = 0;

    private Vector3 paddleposition;

    // Start is called before the first frame update
    void Start()
    {
        paddleposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        Paddlemove();
    }

    private void Paddlemove()
    {
        paddleposition.x += x * speed * Time.deltaTime;
        paddleposition.x = Mathf.Clamp(paddleposition.x, -8f, 8f);
        transform.position = paddleposition;
    }
}
