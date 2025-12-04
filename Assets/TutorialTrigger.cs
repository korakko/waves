using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private bool shown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shown) return;
        if (collision.CompareTag("Player"))
        {
            DialogueManager.instance.ShowDialogue("Hmmm. I should collect these shells. They might be useful.");
            shown = true;
            Destroy(gameObject); // remove tutorial trigger
            //DialogueManager.instance.HideDialogue();
        }
    }
}
