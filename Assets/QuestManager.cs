using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public bool shellQuestComplete = false;
    public bool hatMemoryUnlocked = false;

    public bool bunnyMemoryUnlocked = false;
    void Awake()
    {
        if (instance == null) instance = this;
    }
}

