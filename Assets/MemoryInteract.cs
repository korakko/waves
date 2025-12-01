using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryInteract : MonoBehaviour
{
    public int memoryIndex;            // 0 = hat, 1 = bunny, 2 = book
    public GameObject memoryImageUI;   // The UI image to show
    public string[] dialogueLines;     // Dialogue lines to show for this memory

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

        // Show dialogue line by line
        foreach (string line in dialogueLines)
        {
            DialogueManager.instance.ShowDialogue(line);
            yield return new WaitForSeconds(3);
        }

        // Save memory
        QuestManager.instance.memoryUnlocked[memoryIndex] = true;

        // Prepare next memory
        QuestManager.instance.currentMemoryIndex++;

        yield return new WaitForSeconds(1);

        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();
        DreamMarnieMovement.instance.locked = false;

        QuestManager.instance.currentDayState = QuestManager.DayState.Day;
        SceneManager.LoadScene("HomeScene");
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
