using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Player Die Functionality

            Debug.Log("Player Die ");
            

        }
    }
}
