using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    private float movement = 0;
    Animator animator;
    [SerializeField] private Renderer filling;
    [SerializeField] private GameObject winningPanel;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        filling.material.color = Random.ColorHSV(0, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        animator.SetFloat("xInput", movement);
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Winning Plate")
        {
            
            winningPanel.SetActive(true);
        }
    }
}
