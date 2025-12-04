using UnityEngine;
using System.Collections;
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
 private IEnumerator PlaceShellsCutscene()
    {
        cutscenePlayed = true;
        Debug.Log("Cutscene started!");

        // ----------------------------------------
        // FINAL NIGHT — MEMORY 3 (END OF GAME)
        // ----------------------------------------
        if (QuestManager.instance.currentMemoryIndex == 3)
        {
            plainMound.SetActive(false);
            decoratedMound.SetActive(false);
            DialogueManager.instance.ShowDialogue("I think I'm done collecting shells.");
            yield return new WaitForSeconds(4);

            DialogueManager.instance.ShowDialogue("It's gone...");
            yield return new WaitForSeconds(4);

            DialogueManager.instance.ShowDialogue("You always loved the ocean, didn’t you?");
            yield return new WaitForSeconds(4);

            DialogueManager.instance.ShowDialogue("I’ll miss you.");
            yield return new WaitForSeconds(4);

            DialogueManager.instance.ShowDialogue("Goodbye, Mama.");
            yield return new WaitForSeconds(4);

            DialogueManager.instance.HideDialogue();
            Debug.Log("Final cutscene ended.");
            yield break;
        }

        // ----------------------------------------
        // NORMAL NIGHTS — STILL COLLECTING SHELLS
        // ----------------------------------------
        else
        {
            // Opening line
            DialogueManager.instance.ShowDialogue("Ooh, these shells will look perfect here.");
            yield return new WaitForSeconds(3);

            // Specific dialogue based on memory index
            if (QuestManager.instance.currentMemoryIndex == 0)
            {
                DialogueManager.instance.ShowDialogue("Hmm, let's make it beautiful.");
                yield return new WaitForSeconds(3);
                DialogueManager.instance.ShowDialogue("This looks really special. I hope she likes it.");
            }
            else if (QuestManager.instance.currentMemoryIndex == 1)
            {
                DialogueManager.instance.ShowDialogue("Isn’t this shell pretty? I hope you love it.");
            }
            else if (QuestManager.instance.currentMemoryIndex == 2)
            {
                DialogueManager.instance.ShowDialogue("I used to collect shells with Mama. I don't want to forget her.");
            }
            else
            {
                DialogueManager.instance.ShowDialogue("Mama, I love you.");
            }

            yield return new WaitForSeconds(3);

            // Swap mound visuals
            plainMound.SetActive(false);
            decoratedMound.SetActive(true);
            QuestManager.instance.currentDayState = QuestManager.DayState.Night;
            //FindObjectOfType<RoomSceneLogic>()?.UpdateRoomState();

            DialogueManager.instance.ShowDialogue("There we go! Mama would love this.");
            yield return new WaitForSeconds(3);

            // Go home
            QuestManager.instance.currentDayState = QuestManager.DayState.Night;
            FindObjectOfType<RoomSceneLogic>()?.UpdateRoomState();
            
            DialogueManager.instance.ShowDialogue("I should go home now.");
            yield return new WaitForSeconds(3);

            // Reset shells
            ShellCounter.instance.shellCount = 0;
            ShellCounter.instance.UpdateText();

            // Activate door
            if (homeDoor != null)
                homeDoor.SetActive(true);

            yield return new WaitForSeconds(2);

            DialogueManager.instance.HideDialogue();
            QuestManager.instance.shellQuestComplete = true;
            QuestManager.instance.currentDayState = QuestManager.DayState.Night;

            Debug.Log("Cutscene ended!");
        }
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
