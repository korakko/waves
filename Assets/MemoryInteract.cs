using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // needed for Image component
public class MemoryInteract : MonoBehaviour
{
    public int memoryIndex;            // 0 = hat, 1 = bunny, 2 = book
    public GameObject memoryImageUI;  
    public Sprite memorySprite;  // The UI image to show
    public GameObject[] cutsceneImages;
    public string[] dialogueLines;     // Dialogue lines to show for this memory
    public Image memoryImageComponent;
    private bool playerNearby = false;
    private bool finished = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q) && !finished)
        {
            finished = true;
            StartCoroutine(PlayCutscene());
        }
    }

    private System.Collections.IEnumerator PlayCutscene()
    {
        DreamMarnieMovement.instance.locked = true;
        memoryImageUI.SetActive(true);
        memoryImageComponent.sprite = memorySprite;
        memoryImageUI.gameObject.SetActive(true);

        // Show dialogue line by line
        foreach (string line in dialogueLines)
        {
            DialogueManager.instance.ShowDialogue(line);
            yield return new WaitForSeconds(3);
        }
        // Show cutscene images one by one
        foreach (GameObject img in cutsceneImages)
        {
            img.SetActive(true);
            yield return new WaitForSeconds(2f);
            img.SetActive(false);
        }
        // Save memory
        //QuestManager.instance.memoryUnlocked[memoryIndex] = true;

        // Prepare next memory
        //QuestManager.instance.currentMemoryIndex++;

        //yield return new WaitForSeconds(1);

        // Save memory using index + booleans
        if (memoryIndex == 0)
            QuestManager.instance.hatMemoryUnlocked = true;
        else if (memoryIndex == 1)
            QuestManager.instance.bunnyMemoryUnlocked = true;
        else if (memoryIndex == 2)
            QuestManager.instance.bookMemoryUnlocked = true;

// Also save to the array (optional but helps DreamManager)
        QuestManager.instance.memoryUnlocked[memoryIndex] = true;

// Increase memory index for next night
        QuestManager.instance.currentMemoryIndex++;

        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();
        
        DreamMarnieMovement.instance.locked = false;

        QuestManager.instance.currentDayState = QuestManager.DayState.Day;
        // If all memories unlocked, load Thank You scene
        if (QuestManager.instance.currentMemoryIndex >= QuestManager.instance.totalMemories)
        {
                SceneManager.LoadScene("ThankYouScene"); // <-- your separate scene
        }
        else
        {
            //SceneManager.LoadScene("HomeScene"); // normal home scene
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = false;
    }
}
