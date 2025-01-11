using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 forceDirection;
    [SerializeField] float forceSpeed;


    [SerializeField] GameObject ball1;
    private void Start()
    {
        rb.AddForce(forceDirection ,ForceMode2D.Impulse);
    }


    public void SpwanNewBall()
    {
        if(ball1 != null)
        {
            
            GameObject obj1 = Instantiate(ball1, rb.position + Vector2.right/4, Quaternion.identity);
            
          
            
            GameObject obj2 = Instantiate(ball1,rb.position + Vector2.left/4, Quaternion.identity);

            
        }

        Destroy(gameObject);


    }

}
