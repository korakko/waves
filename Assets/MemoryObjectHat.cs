using UnityEngine;

public class MemoryObject : MonoBehaviour
{
    public GameObject memoryImageUI;

    private bool playerNearby = false;
    private bool seenMemory = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q) && !seenMemory)
        {
            seenMemory = true;
            StartCoroutine(PlayMemoryCutscene());
        }
    }

    private System.Collections.IEnumerator PlayMemoryCutscene()
    {
        Debug.Log("Instance: " + DreamMarnieMovement.instance);
        Debug.Log("RB: " + (DreamMarnieMovement.instance != null ? DreamMarnieMovement.instance.rb : null));

        // STOP MOVEMENT
        DreamMarnieMovement.instance.locked = true;
        DreamMarnieMovement.instance.rb.linearVelocity = Vector2.zero;

        // SHOW MEMORY IMAGE
        memoryImageUI.SetActive(true);

        // SHOW DIALOGUE
        DialogueManager.instance.ShowDialogue("It's... it's my hat. Mama? Mama gave this to me. I remember now.");

        yield return new WaitForSeconds(7);

        // HIDE IMAGE + UNFREEZE MOVEMENT
        memoryImageUI.SetActive(false);
        DialogueManager.instance.HideDialogue();
        DreamMarnieMovement.instance.locked = false;
        QuestManager.instance.hatMemoryUnlocked = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerNearby = false;
    }
}
