using UnityEngine;

public class BombMover : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get all AudioSources from the player
            AudioSource[] audioSources = other.GetComponents<AudioSource>();
            if (audioSources.Length > 0)
            {
                int audioSourceIndex = 1; // Set this based on which AudioSource you want to play, this mean playing the second Audio Clip

                if (audioSources[audioSourceIndex] != null)
                {
                    // Play the specific AudioSource
                    audioSources[audioSourceIndex].Play();
                    Debug.Log("Playing sound from player AudioSource index: " + audioSourceIndex);
                }
                else
                {
                    Debug.LogError("AudioSource at index " + audioSourceIndex + " is not available.");
                }
            }
            else
            {
                Debug.LogError("No AudioSource found on the player object.");
            }

            Destroy(gameObject);
            ScoreManager.AddScore(-1);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
