using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //start animation
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

    }
}
