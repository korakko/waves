using UnityEngine;

public class RoomSceneLogic : MonoBehaviour
{
    public GameObject bedtimeBedTrigger;
    public GameObject morningDoorTrigger;

    void Start()
    {
        UpdateRoomState();
    }

    public void UpdateRoomState()
    {
        if (QuestManager.instance.currentDayState == QuestManager.DayState.Day)
        {
            ShowMorningState();
        }
        else
        {
            ShowNightState();
        }
    }

    void ShowMorningState()
    {
        // morning logic
        DialogueManager.instance.ShowDialogue("It's morning! I should get some fresh air.");

        int mem = QuestManager.instance.currentMemoryIndex;

        if (mem == 1)
            DialogueManager.instance.ShowDialogue("That was a strange dream... I should go out.");
        else if (mem == 2)
            DialogueManager.instance.ShowDialogue("I remember now...");
        else if (mem >= 3)
            DialogueManager.instance.ShowDialogue("I feel... different.");

        // triggers
        bedtimeBedTrigger.SetActive(false);
        morningDoorTrigger.SetActive(true);
    }

    void ShowNightState()
    {
        // night logic
        DialogueManager.instance.ShowDialogue("I feel sleepy... I should go to bed...");

        // triggers
        bedtimeBedTrigger.SetActive(true);
        morningDoorTrigger.SetActive(false);
    }
}
