using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpriteManagerTMP : MonoBehaviour
{
    public static SpriteManagerTMP Instance { get; private set; }

    [System.Serializable]
    public class SpriteChange
    {
        public string targetGameObjectTag; // Use tag to identify the GameObject
        public List<Sprite> sprites;
        public List<RuntimeAnimatorController> animators; // Array of Animator Controllers
        public int currentSpriteIndex = 0; // Stores the current sprite index
        public int currentAnimatorIndex = 0; // Stores the current animator index
    }

    public List<SpriteChange> spriteChanges;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(ReapplySpritesWithDelay());
    }

    private IEnumerator ReapplySpritesWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before applying sprite changes
        ReapplySprites();
    }

    public void ChangeSprite(int index, int spriteChangeIndex)
    {
        if (spriteChangeIndex < spriteChanges.Count)
        {
            var spriteChange = spriteChanges[spriteChangeIndex];
            if (index < spriteChange.sprites.Count)
            {
                spriteChange.currentSpriteIndex = index;
                if (index < spriteChange.animators.Count)
                    spriteChange.currentAnimatorIndex = index; // Set animator index only if in range
                ReapplySprite(spriteChangeIndex);
            }
        }
    }

    private void ReapplySprites()
    {
        for (int i = 0; i < spriteChanges.Count; i++)
        {
            ReapplySprite(i);
        }
    }

    private void ReapplySprite(int index)
    {
        if (index < spriteChanges.Count)
        {
            var spriteChange = spriteChanges[index];
            GameObject go = GameObject.FindGameObjectWithTag(spriteChange.targetGameObjectTag);
            if (go != null)
            {
                SpriteRenderer renderer = go.GetComponent<SpriteRenderer>();
                Animator animator = go.GetComponent<Animator>(); // Get the Animator component

                // Check if the SpriteRenderer exists and apply the sprite if it does
                if (renderer != null && spriteChange.currentSpriteIndex < spriteChange.sprites.Count)
                {
                    renderer.sprite = spriteChange.sprites[spriteChange.currentSpriteIndex];
                }

                // Check if the Animator exists and apply the animator controller if it does
                if (animator != null && spriteChange.currentAnimatorIndex < spriteChange.animators.Count)
                {
                    animator.runtimeAnimatorController = spriteChange.animators[spriteChange.currentAnimatorIndex];
                }
            }
        }
    }
}


///Spriites only
//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using System.Collections;
//using TMPro;

//public class SpriteManagerTMP : MonoBehaviour
//{
//    public static SpriteManagerTMP Instance { get; private set; }
//    [System.Serializable]
//    public class SpriteChange
//    {
//        public string targetGameObjectTag; // Use tag to identify the GameObject
//        public List<Sprite> sprites;
//        public int currentSpriteIndex = 0; // Stores the current sprite index
//    }

//    public List<SpriteChange> spriteChanges;

//    /// <summary>
//    /// Upon Loading Scene, do not destroy this instance
//    /// </summary>
//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//        // Register to listen to scene load events
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }

//    private void OnDestroy()
//    {
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        //Invoke sprite re-apply on scene loaded
//        StartCoroutine(ReapplySpritesWithDelay());

//    }

//    /// <summary>
//    /// Scene loaded done
//    /// </summary>


//    //Step 1: Logic to reapply Sprites
//    private IEnumerator ReapplySpritesWithDelay()
//    {
//        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before applying sprite changes
//        ReapplySprites();
//    }

//    public void ChangeSprite(int index, int spriteChangeIndex)
//    {
//        if (spriteChangeIndex < spriteChanges.Count && index < spriteChanges[spriteChangeIndex].sprites.Count)
//        {
//            spriteChanges[spriteChangeIndex].currentSpriteIndex = index;
//            ReapplySprite(spriteChangeIndex);
//        }
//    }

//    private void ReapplySprites()
//    {
//        for (int i = 0; i < spriteChanges.Count; i++)
//        {
//            ReapplySprite(i);
//        }
//    }

//    private void ReapplySprite(int index)
//    {
//        if (index < spriteChanges.Count)
//        {
//            var spriteChange = spriteChanges[index];
//            GameObject go = GameObject.FindGameObjectWithTag(spriteChange.targetGameObjectTag);
//            if (go != null)
//            {
//                SpriteRenderer renderer = go.GetComponent<SpriteRenderer>();
//                if (renderer != null && spriteChange.currentSpriteIndex < spriteChange.sprites.Count)
//                {
//                    renderer.sprite = spriteChange.sprites[spriteChange.currentSpriteIndex];
//                }
//            }
//        }
//    }




//}
