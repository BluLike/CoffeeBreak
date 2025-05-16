using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    private Animator animator;

    public bool canMove = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (canMove)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");


            Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime;
            transform.position = newPosition;

            UpdateAnimation(moveX, moveY);
        }
        else
        {
            animator.SetBool("idle", true);
        }
        
    }

    void UpdateAnimation(float moveX, float moveY)
    {
        if (moveX > 0)
        {
            animator.SetBool("idle", false);
            animator.Play("ProtaWalkRight"); // Moves Right
        }
        else if (moveX < 0)
        {
            animator.SetBool("idle", false);
            animator.Play("ProtaWalkLeft"); // Moves Left
        }
        else if (moveY > 0)
        {
            animator.SetBool("idle", false);
            animator.Play("ProtaWalkBack"); // Moves Up
        }
        else if (moveY < 0)
        {
            animator.SetBool("idle", false);
            animator.Play("ProtaWalkFront"); // Moves down
        }
        else
        {
            animator.SetBool("idle", true); // Idle
        }
    }
}
