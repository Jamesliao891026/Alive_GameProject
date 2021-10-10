using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    //public GameObject player;

    public Animator animator;

    Vector2 maxPosition;
    Vector2 minPosition;

    Vector2 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.velocity = movement.normalized * moveSpeed;

        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x), Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y), transform.position.z);

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //rb.position = new Vector3(Mathf.Clamp(rb.position.x, minPosition.x, maxPosition.x), Mathf.Clamp(rb.position.y, minPosition.y, maxPosition.y), transform.position.z);

    }
    public void SetBounds(Vector2 minPos , Vector2 maxPos)
    {
        minPosition = minPos + new Vector2(0.5f,1f);
        maxPosition = maxPos - new Vector2(0.5f,1f);
    }
}
