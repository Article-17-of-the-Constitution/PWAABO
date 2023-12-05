using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float bounceAngleRange = 60f;
    public float yourBallSpeed = 10.0f;

    void Start()
    {

    }

    
    void Update()
    {

    }

    public void Reset()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // �е��� �߽ɰ� �浹 ���� ���� ������� ��ġ�� ���
            float relativePosition = (collision.transform.position.x - transform.position.x) / (transform.localScale.x / 2);

            // Ƣ�� ������ ��� (������� ��ġ�� �������)
            float bounceAngle = relativePosition * bounceAngleRange;

            // Ƣ�� ������ �����Ͽ� ���� ������ ����
            Vector2 newDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * bounceAngle), Mathf.Sin(Mathf.Deg2Rad * bounceAngle));
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newDirection * yourBallSpeed;
        }
    }
}
