using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float maxPosition;
    [SerializeField] Rigidbody2D rb;
    
    private Vector3 startingPosition;
    private Vector3 mousePosition;
    private bool isDrag;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, Input.mousePosition.z));
            startingPosition = transform.position;

            isDrag = true;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }


    }

    private void FixedUpdate()
    {
        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z)) - startingPosition;

            float xMovement = mousePos.x / Screen.width * playerSpeed;

            Vector3 newPosition = startingPosition + new Vector3(xMovement, 0, 0);

            newPosition.x = Mathf.Clamp(newPosition.x, -maxPosition, maxPosition);

            transform.position = newPosition;


            if(EventManager.Instance.iswait)
            {
                StartCoroutine(EventManager.Instance.FireBulletEvent());
            }
            
        }
    }

  
}
