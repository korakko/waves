using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public bool shellQuestComplete = false;
    public bool hatMemoryUnlocked = false;

    public bool bunnyMemoryUnlocked = false;
    public bool bookMemoryUnlocked = false;
    public int currentMemoryIndex = 0;
    public int totalMemories = 3;
    public bool[] memoryUnlocked;
    public enum DayState { Day, Night }
    public DayState currentDayState = DayState.Day;
    void Awake()
    {
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        memoryUnlocked = new bool[totalMemories];
    }
    else
    {
        Destroy(gameObject);
    }
    }
}

