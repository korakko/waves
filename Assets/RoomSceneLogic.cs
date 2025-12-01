using UnityEngine;

public class RoomSceneLogic : MonoBehaviour
{
    public GameObject bedtimeBedTrigger;
    public GameObject morningDoorTrigger;

    void Start()
    {
        if (QuestManager.instance.currentDayState == QuestManager.DayState.Day)
        //QuestManager.instance.currentDayState = QuestManager.DayState.Night;
        {
            DialogueManager.instance.ShowDialogue("It's morning! I should get some fresh air.");

            if (QuestManager.instance.currentMemoryIndex == 1)
            {
                DialogueManager.instance.ShowDialogue("That was a strange dream... I should go out.");
            }
            else if (QuestManager.instance.currentMemoryIndex == 2)
            {
                DialogueManager.instance.ShowDialogue("I remember now...");
            }
            else if (QuestManager.instance.currentMemoryIndex >= 3)
            {
                DialogueManager.instance.ShowDialogue("I feel... different.");
            }
            bedtimeBedTrigger.SetActive(false);
            morningDoorTrigger.SetActive(true);
        }
        else
        {
            DialogueManager.instance.ShowDialogue("I feel sleepy... I should go to bed...");

            bedtimeBedTrigger.SetActive(true);
            morningDoorTrigger.SetActive(false);
        }
    }
}
