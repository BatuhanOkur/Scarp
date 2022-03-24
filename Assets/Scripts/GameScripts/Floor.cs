using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOnFloor;
    Animator animator;
    int specialFloorChance,goldenFloorChance;
    float jumpingForce;
    public int addition = 1;
    private void Start()
    {
        animator = GetComponent<Animator>();
        specialFloorChance = Random.Range(1, 11);
        goldenFloorChance = Random.Range(1, 11);

        if (specialFloorChance == 1)
        {
            animator.SetBool("isSpecialFloor", true);
            jumpingForce = 25f;
        }
        else if(goldenFloorChance == 1)
        {
            animator.SetBool("isGoldenFloor", true);
            jumpingForce = 30f;
        }
        else
        {
            jumpingForce = 0f;
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 jumpingVelocity = rb.velocity;
                jumpingVelocity.y = jumpingForce;
                rb.velocity = jumpingVelocity;
                if (isOnFloor == false)
                {
                    if(specialFloorChance == 1)
                    {
                        addition *= 2;
                    }
                    else if(goldenFloorChance == 1)
                    {
                        addition *= 3;                     
                    }

                    isOnFloor = true;
                    Manager.scoreCount += addition;
                }
                animator.SetBool("isTouching", true);
                Destroy(gameObject, .4f);
            }
        }
    }

    //IEnumerator PowerUp()
    //{
    //    CharacterMovement cm = new CharacterMovement();
    //    cm.jumpamount = 25f;
    //    addition = 3;
    //    yield return new WaitForSeconds(10);
    //}
}
