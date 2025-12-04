using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryUI : MonoBehaviour
{
    public static MemoryUI instance;

    public GameObject panel;
    public Image imageDisplay;
    public TMP_Text dialogueDisplay;

    // Assign the images for each memory in inspector
    public Sprite hatMemorySprite;
    public Sprite bunnyMemorySprite;
    public Sprite bookMemorySprite;

    void Awake()
    {
        instance = this;
        panel.SetActive(false);
    }

    public void Show(string dialogue)
    {
        panel.SetActive(true);
        dialogueDisplay.text = dialogue;

        // Choose image based on current memory index
        int index = QuestManager.instance.currentMemoryIndex;

        if (index == 0)
        {
            imageDisplay.sprite = hatMemorySprite;
        }
        else if (index == 1)
        {
            imageDisplay.sprite = bunnyMemorySprite;
        }
        else if (index == 2)
        {
            imageDisplay.sprite = bookMemorySprite;
        }
        else
        {
            imageDisplay.sprite = null; // fallback if index is out of range
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
