using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime );

        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
               
            EventManager.Instance.NextSpwanBallEvent(ball);
            EventManager.Instance.IncreesBallNumberEvent();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.totalBall -= 1;

            if(GameManager.Instance.totalBall <= 0)
            {
                EventManager.Instance.PlayerWinEvent();
            }


        }
    }
}
