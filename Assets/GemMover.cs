using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMover : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); //chuyển động phương thẳng đứng
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audioSource = other.GetComponent<AudioSource>();

        //Debug.Log("detect collision of gem and object");
        //Debug.Log("processing collision");
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("gem collided with character");
            Destroy(gameObject);
            //Debug.Log("gem removed");
            ScoreManager.AddScore(1);
            audioSource.Play();

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("gem collided with ground");
            Destroy(gameObject);
            //Debug.Log("gem removed");

        }
    }
}
