using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePlatform : MonoBehaviour
{
    [Header("Plates Jump Force")]
    public float jumpForce = 10f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            // Gets the animator and the rigidbody of the character
            Animator animator = collision.collider.GetComponent<Animator>();
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply force to the rb y. Set animation. Destroy the plate.
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                animator.SetTrigger("Jump");
                Destroy(this.gameObject);
            }
        }
    }
}
