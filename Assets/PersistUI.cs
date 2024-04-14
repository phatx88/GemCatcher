using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistUI : MonoBehaviour
{
    public static PersistUI Instance;
    [SerializeField] private GameObject dropdownUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Add logic here if needed to show/hide UI based on the scene
        if (scene.name == "Settings")
        {
            dropdownUI.SetActive(true);
        }
        else
        {
            dropdownUI.SetActive(false);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
