using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    Animator animator;
    private float movement = 0;

    [Header("Character Attributes")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Renderer filling;

    [Header("Win Panel")]
    [SerializeField] private GameObject winningPanel;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the components and setting the filling color
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        filling.material.color = Random.ColorHSV(0, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Setting movement and the animation
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        animator.SetFloat("xInput", movement);
    }

    private void FixedUpdate()
    {
        // This sets and resets the x velocity each fixed update.
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // When making contact with the winning plate, pause game and show the win panel
        if(collision.gameObject.tag == "Winning Plate")
        {
            Time.timeScale = 0;
            winningPanel.SetActive(true);
        }
    }
}
