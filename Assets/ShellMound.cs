using UnityEngine;

public class Mound : MonoBehaviour
{
    public int requiredShells = 5;

    public GameObject homeDoor;  
    public GameObject plainMound; 
    public GameObject decoratedMound; 

    private bool playerNearby = false;
    private bool cutscenePlayed = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            if (cutscenePlayed) return;

            if (ShellCounter.instance.shellCount >= requiredShells)
            {
                StartCoroutine(PlaceShellsCutscene());
            }
            else
            {
                DialogueManager.instance.ShowDialogue(
                    "I should decorate this. I'm gonna need more shells..."
                );
            }
        }
    }

    private System.Collections.IEnumerator PlaceShellsCutscene()
    {
        cutscenePlayed = true;

        DialogueManager.instance.ShowDialogue("Hmm, let's make it beautiful.");
        yield return new WaitForSeconds(5);

        // swap mound visuals
        plainMound.SetActive(false);
        decoratedMound.SetActive(true);

        DialogueManager.instance.ShowDialogue("There we go! Mama would love this.");
        yield return new WaitForSeconds(5);

        DialogueManager.instance.ShowDialogue("I should go home now.");
        yield return new WaitForSeconds(5);
        // reset shells
        ShellCounter.instance.shellCount = 0;
        ShellCounter.instance.UpdateText();  // works if you add UpdateText()

        if (homeDoor != null)
            homeDoor.SetActive(true);

        yield return new WaitForSeconds(2);

        DialogueManager.instance.HideDialogue();
        QuestManager.instance.shellQuestComplete = true;
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
