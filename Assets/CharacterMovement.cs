using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //start animation

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //nhan input cua nguoi dung A = -1 & W = 1
        bool isMoving = moveHorizontal != 0; // khai bao bien isMoving
        animator.SetBool("isMoving", isMoving); // gan gia tri nhap duoc vao paramete isMoving cua Animator

        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
        //kiem tra co input jump cua nguoi dung va character dang o trang thai grounded
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; //set isgrounded to prevent double jump
        }


    }

    //ham kiem tra va set character vao trang thai tram dat
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
