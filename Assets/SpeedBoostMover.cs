using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostMover : MonoBehaviour
{
    public float speed = 4f;
    public float boostDuration = 2f; // Duration of the speed boost

    private SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Handle audio playback
            PlayAudio(other);

            // Disable sprite and collider to simulate the object being "collected"
            spriteRenderer.enabled = false;
            collider2D.enabled = false;

            // Apply the speed boost to the player
            CharacterMovement characterMovement = other.GetComponent<CharacterMovement>();
            if (characterMovement != null)
            {
                StartCoroutine(ApplySpeedBoost(characterMovement));
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void PlayAudio(Collider2D player)
    {
        AudioSource[] audioSources = player.GetComponents<AudioSource>();
        int audioSourceIndex = 3; // Make sure this index is within the bounds
        if (audioSourceIndex < audioSources.Length && audioSources[audioSourceIndex] != null)
        {
            audioSources[audioSourceIndex].Play();
            Debug.Log("Playing sound from player AudioSource index: " + audioSourceIndex);
        }
        else
        {
            Debug.LogError("AudioSource at index " + audioSourceIndex + " is not available.");
        }
    }

    IEnumerator ApplySpeedBoost(CharacterMovement characterMovement)
    {
        float originalSpeed = characterMovement.speed;
        characterMovement.speed = originalSpeed * 2; // Double the speed
        yield return new WaitForSeconds(boostDuration); // Wait for the duration of the boost
        characterMovement.speed = originalSpeed; // Reset to original speed
        Debug.Log("Speed boost ended, resetting speed.");

        // Destroy the GameObject after the effect ends
        Destroy(gameObject);
    }
}
