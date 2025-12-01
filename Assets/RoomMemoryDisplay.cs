using UnityEngine;

public class RoomMemoryDisplay : MonoBehaviour
{
    public GameObject[] roomItems; // hat, bunny, book

    void Start()
    {
        RoomBook.SetActive(QuestManager.instance.bookMemoryUnlocked);
        RoomHat.SetActive(QuestManager.instance.hatMemoryUnlocked);
        RoomBunny.SetActive(QuestManager.instance.bunnyMemoryUnlocked);
        for (int i = 0; i < roomItems.Length; i++)
        {
            roomItems[i].SetActive(QuestManager.instance.memoryUnlocked[i]);
        }
    }
}

