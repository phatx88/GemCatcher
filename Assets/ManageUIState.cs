using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageUIState : MonoBehaviour
{
    [System.Serializable]
    public class UIState
    {
        public string dropdownTag; // Tag to find the dropdown GameObject
        public int selectedIndex = 0; // Last selected index of the dropdown
    }

    public List<UIState> dropdownStates;

    public static ManageUIState Instance { get; private set; }

    // Define an event to notify when the state has been loaded
    public delegate void OnStateLoaded();
    public static event OnStateLoaded onStateLoaded;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(RestoreUIWithDelay());
    }

    private IEnumerator RestoreUIWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // Delay to ensure all GameObjects are loaded
        LoadDropdownState();
        // Notify other components that the UI state is ready
        onStateLoaded?.Invoke();
    }

    private void LoadDropdownState()
    {
        foreach (var state in dropdownStates)
        {
            TMP_Dropdown dropdown = GameObject.FindGameObjectWithTag(state.dropdownTag).GetComponent<TMP_Dropdown>();
            if (dropdown != null)
            {
                dropdown.value = state.selectedIndex;
                dropdown.RefreshShownValue();
                // Add a listener to save the state whenever the value changes
                dropdown.onValueChanged.AddListener(delegate { SaveState(); });
            }
            else
            {
                Debug.LogError($"Failed to find TMP_Dropdown component on GameObject with tag: {state.dropdownTag}");
            }
        }
    }

    public void SaveState()
    {
        SaveDropdownState();
    }

    private void SaveDropdownState()
    {
        foreach (var state in dropdownStates)
        {
            TMP_Dropdown dropdown = GameObject.FindGameObjectWithTag(state.dropdownTag).GetComponent<TMP_Dropdown>();
            if (dropdown != null)
            {
                state.selectedIndex = dropdown.value;
            }
        }
    }
}
