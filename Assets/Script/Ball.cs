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
           
            GameObject obj1 = Instantiate(nextPrefeb, rb.position + Vector2.right / 4, Quaternion.identity);
            obj1.GetComponent<Ball>().forceDirection = new Vector2(2f, 5f);
            obj1.GetComponent<Ball>().nextPrefeb = GameManager.Instance.NextObject();
                 
            GameObject obj2 = Instantiate(nextPrefeb, rb.position + Vector2.left / 4, Quaternion.identity);
            obj2.GetComponent<Ball>().forceDirection = new Vector2(-2f, 5f);
            obj2.GetComponent<Ball>().nextPrefeb = GameManager.Instance.NextObject();


            
        }



      
    }


    private void OnDisable()
    {
        EventManager.Instance.NextBallSpwan -= SpwanNewBall;
    }
}
