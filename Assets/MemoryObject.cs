using UnityEngine;
using UnityEngine.SceneManagement;
public class MemoryObject : MonoBehaviour
{
    public enum MemoryType { Hat, Bunny, Book }
    public MemoryType memoryType;

    public GameObject memoryImageUI;

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
        // freeze player
        DreamMarnieMovement.instance.locked = true;

        memoryImageUI.SetActive(true);

        if (memoryType == MemoryType.Hat)
        {
            QuestManager.instance.hatMemoryUnlocked = true;
            DialogueManager.instance.ShowDialogue("My hat… Mama gave this to me.");
        }
        else if (memoryType == MemoryType.Bunny)
        {
            QuestManager.instance.bunnyMemoryUnlocked = true;
            DialogueManager.instance.ShowDialogue("Someone must have bunny.");
        }
        else if (memoryType == MemoryType.Book)
        {
            QuestManager.instance.bookMemoryUnlocked = true;
            DialogueManager.instance.ShowDialogue("My little storybook… I remember reading this.");
        }

        // Move to next memory for next night
        QuestManager.instance.currentMemoryIndex++;

        yield return new WaitForSeconds(5);

        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();

        DreamMarnieMovement.instance.locked = false;

        // return to home
        SceneManager.LoadScene("HomeScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearby = false;
    }
}
