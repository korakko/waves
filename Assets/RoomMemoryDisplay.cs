using UnityEngine;

public class RoomMemoryDisplay : MonoBehaviour
{
    public GameObject[] roomItems; // hat, bunny, book

    void Start()
    {
        for (int i = 0; i < roomItems.Length; i++)
        {
            roomItems[i].SetActive(QuestManager.instance.memoryUnlocked[i]);
        }
    }
}

