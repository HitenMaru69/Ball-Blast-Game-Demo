using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 forceDirection;
    [SerializeField] float forceSpeed;
    [SerializeField] int number;

    public GameObject nextPrefeb;
    

    private void Start()
    {
        rb.AddForce(forceDirection ,ForceMode2D.Impulse);

        EventManager.Instance.NextBallSpwan -= SpwanNewBall;

        EventManager.Instance.NextBallSpwan += SpwanNewBall;

    }

    public void SpwanNewBall(object sender,EventArgs e)
    {
     
        if (this != sender) return;

        if (nextPrefeb != null)
        {
 
            CreateBall(Vector2.right / 4, new Vector2(2f, 5f)); 
            CreateBall(Vector2.left / 4, new Vector2(-2f, 5f)); 

        }
      
    }

    void CreateBall(Vector2 offset, Vector2 forceDirection)
    {
        GameObject obj = Instantiate(nextPrefeb, rb.position + offset, Quaternion.identity);
        GameManager.Instance.totalBall += 1;

        Ball ball = obj.GetComponent<Ball>();
        if (ball != null)
        {
            ball.forceDirection = forceDirection;
            int ballNumber = ball.number;
            ball.nextPrefeb = GameManager.Instance.NextObject(ballNumber);
        }
    }


    private void OnDisable()
    {
        EventManager.Instance.NextBallSpwan -= SpwanNewBall;
    }
}
