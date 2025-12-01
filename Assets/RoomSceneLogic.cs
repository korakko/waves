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
            DialogueManager.instance.ShowDialogue("A new day… I should go to the beach.");

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
