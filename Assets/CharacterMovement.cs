using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7f;
    private int maxJumpCount = 2;  // Maximum number of jumps (1 for normal, 2 for double jump)
    private int jumpCount;  // Current number of jumps performed

    private Rigidbody2D rb;
    private Animator animator;

    // Define boundaries
    public float minX = -16f;
    public float maxX = 16f;
    public float minY = -5f;
    public float maxY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize animation
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;  // Initialize jump count
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        ClampPosition();
    }

    //Logic to Moving & Jumping Character 
    void MoveCharacter()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Receive user input for horizontal movement
        bool isMoving = moveHorizontal != 0; // Determine if there is movement
        animator.SetBool("isMoving", isMoving); // Set the Animator parameter based on movement

        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }

        // Handle jump input when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < maxJumpCount)
            {
                rb.velocity = Vector2.up * jumpForce; // Use velocity to ensure consistent jump height
                jumpCount++;  // Increment jump count each time a jump is performed

                //Add Audio Source for the jump
                AudioSource[] audioSources = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
                int audioSourceIndex = 5; // Assuming this index is correctly set for the desired sound

                if (audioSources.Length > audioSourceIndex && audioSources[audioSourceIndex] != null)
                {
                    audioSources[audioSourceIndex].Play();
                    Debug.Log("Playing sound from player AudioSource index: " + audioSourceIndex);
                }
                else
                {
                    Debug.LogError("AudioSource at index " + audioSourceIndex + " is not available or not enough AudioSources.");
                }
            }
        }
    }

    //ClampPosition to ensure Character not moving out of scene boundary
    void ClampPosition()
    {
        // Clamp position of the character within the boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    // Check collision to reset jump counter if character lands on the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Stationary")
        {
            jumpCount = 0;  // Reset jump count when character touches the ground
        }
    }
}
