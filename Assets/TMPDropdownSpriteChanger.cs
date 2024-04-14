using UnityEngine;
using TMPro;

public class TMPDropdownSpriteChanger : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int spriteChangeIndex;  // Index to identify which SpriteChange set to use

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        SpriteManagerTMP.Instance.ChangeSprite(index, spriteChangeIndex);
    }

    private void OnDestroy()
    {
        dropdown.onValueChanged.RemoveAllListeners();
    }

}
