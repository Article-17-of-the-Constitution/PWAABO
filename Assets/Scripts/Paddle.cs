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
            // 패들의 중심과 충돌 지점 간의 상대적인 위치를 계산
            float relativePosition = (collision.transform.position.x - transform.position.x) / (transform.localScale.x / 2);

            // 튀는 각도를 계산 (상대적인 위치를 기반으로)
            float bounceAngle = relativePosition * bounceAngleRange;

            // 튀는 각도를 적용하여 공의 방향을 조절
            Vector2 newDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * bounceAngle), Mathf.Sin(Mathf.Deg2Rad * bounceAngle));
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newDirection * yourBallSpeed;
        }
    }
}
