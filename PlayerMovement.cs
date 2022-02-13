using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public GrabController grabController;


    Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float increasedGravity = 10f;

    public float normalGravityScale;
    public float newGravityScale; 

    [Header("Bools")]
    [SerializeField] bool isGrounded = false;

    [SerializeField] bool isHoldingItem = false;
    







    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grabController.isHoldingItem = false;

        grabController = GetComponent<GrabController>();

        normalGravityScale = 0.5f; 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Move * Time.deltaTime * moveSpeed;
        Jump();


    }

   public void FixedUpdate()
    {
        if (grabController.isHoldingItem)
        {
            rb.gravityScale = newGravityScale;
            
        }
        else
        {
            rb.gravityScale = normalGravityScale;

        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
}
