using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody2D rb;
    public Animator animator;

    float speedAmount = 10f;
    public float jumpamount = 18f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        Jump();
    }

    void Run()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.AddForce(Vector3.up * jumpamount, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        if(animator.GetBool("isJumping")&& Mathf.Approximately(rb.velocity.y, 0))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
