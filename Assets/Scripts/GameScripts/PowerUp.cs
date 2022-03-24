using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Animator anim;
    float increase = 14f;
    int additionInc = 3;
    GameObject character;
    CharacterMovement characterScript;
    Floor floorscript = new Floor();
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            character = collision.gameObject;
            characterScript = character.GetComponent<CharacterMovement>();
            if (rb != null)
            {
                if (anim.GetBool("isGoldenFloor") == true)
                {
                    StartCoroutine(GetPowerUp());
                }
               
               
            }
        }
    }

    IEnumerator GetPowerUp()
    {
        characterScript.jumpamount += increase;
        floorscript.addition += additionInc;
        yield return new WaitForSeconds(10);
        characterScript.jumpamount -= increase;
        floorscript.addition -= additionInc;
    }
}
