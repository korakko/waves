using UnityEngine;

public class RoomMemoryDisplay : MonoBehaviour
{
    public GameObject hat;
    public GameObject bunny;

    void Start()
    {
        if (QuestManager.instance.hatMemoryUnlocked)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

        if (QuestManager.instance.bunnyMemoryUnlocked)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
