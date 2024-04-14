using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoostMover : MonoBehaviour
{
    public float speed = 4f;
    public List<Sprite> sprites; // List of sprites to choose from
    public List<int> scoreValues = new List<int>() { 3, -3 }; // Score increments
    private SpriteRenderer spriteRenderer; // Sprite Renderer component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Count > 0 && spriteRenderer != null)
        {
            int spriteIndex = Random.Range(0, sprites.Count);
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprites not set or Sprite Renderer not found.");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource[] audioSources = other.GetComponents<AudioSource>();
            int audioSourceIndex = 4; // Assuming this index is correctly set for the desired sound

            if (audioSources.Length > audioSourceIndex && audioSources[audioSourceIndex] != null)
            {
                audioSources[audioSourceIndex].Play();
                Debug.Log("Playing sound from player AudioSource index: " + audioSourceIndex);
            }
            else
            {
                Debug.LogError("AudioSource at index " + audioSourceIndex + " is not available or not enough AudioSources.");
            }

            if (spriteRenderer != null && sprites.Contains(spriteRenderer.sprite))
            {
                int index = sprites.IndexOf(spriteRenderer.sprite);
                if (index < scoreValues.Count)
                {
                    ScoreManager.AddTime(scoreValues[index]);
                }
            }
            else
            {
                Debug.LogError("Error: Sprite not found in list or Sprite Renderer missing.");
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
