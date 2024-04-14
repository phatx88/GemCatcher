using UnityEngine;
using TMPro;

public class PlayerSpriteChanger : MonoBehaviour
{
    public static PlayerSpriteChanger Instance { get; private set; }

    // Now storing references to the Animator and SpriteRenderer which will be fetched at runtime.
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    public RuntimeAnimatorController[] animators; // Assigned in the inspector.
    public Sprite[] sprites;                      // Assigned in the inspector.

    private void Awake()
    {
        // Ensuring only one instance of this component is active using a singleton pattern.

        // Fetch player components.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

            if (playerAnimator == null || playerSpriteRenderer == null)
            {
                Debug.LogError("Required components (Animator or SpriteRenderer) are missing on the player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found.");
        }
    }

    private void Start()
    {
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(ChangePlayerProperties);

            // Load last selected index if available
            int selectedIndex = PlayerPrefs.GetInt("SelectedAnimatorIndex", 0);
            dropdown.value = selectedIndex;
            ApplyChanges(selectedIndex);
        }
        else
        {
            Debug.LogError("Dropdown component not found on the GameObject.");
        }
    }

    private void ChangePlayerProperties(int index)
    {
        PlayerPrefs.SetInt("SelectedAnimatorIndex", index);
        PlayerPrefs.Save();
        ApplyChanges(index);
    }

    private void ApplyChanges(int index)
    {
        if (playerAnimator != null && playerSpriteRenderer != null)
        {
            if (index >= 0 && index < animators.Length && index < sprites.Length)
            {
                playerAnimator.runtimeAnimatorController = animators[index];
                playerSpriteRenderer.sprite = sprites[index];
            }
            else
            {
                Debug.LogError("Index out of range. Ensure the dropdown indices match the arrays.");
            }
        }
        else
        {
            Debug.LogError("Animator or SpriteRenderer not properly initialized.");
        }
    }
}
