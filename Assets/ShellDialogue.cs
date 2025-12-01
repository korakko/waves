using UnityEngine;

public class ShellDialogue : MonoBehaviour
{
    public string[] earlyLines = {
        "This one looks nice.",
        "This one feels special.",
        "This is pretty."
    };

    public string[] midLines = {
        "She would've liked this one.",
        "I remember finding a shell like this with her.",
        "This shell reminds me of her."

    };

    public string[] lateLines = {
        "I don't need these anymore."
    };

    private bool playerNearby;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q))
            Speak();
    }

    void Speak()
    {
        if (QuestManager.instance.currentMemoryIndex == 0)
            DialogueManager.instance.ShowDialogue(RandomLine(earlyLines));

        else if (QuestManager.instance.currentMemoryIndex == 1)
            DialogueManager.instance.ShowDialogue(RandomLine(midLines));

        else if (QuestManager.instance.currentMemoryIndex == 2)
            DialogueManager.instance.ShowDialogue(RandomLine(midLines));

        else
            DialogueManager.instance.ShowDialogue(RandomLine(lateLines));
    }

    string RandomLine(string[] arr)
    {
        int i = Random.Range(0, arr.Length);
        return arr[i];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) playerNearby = false;
    }
}
