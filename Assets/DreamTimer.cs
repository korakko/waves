using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DreamTimer : MonoBehaviour
{
    public float dreamDuration = 60f;
    public TextMeshProUGUI timerText;

    private float timeLeft;

    void Start()
    {
        timeLeft = dreamDuration;

        // Stop timer from running if something is missing
        if (timerText == null)
        {
            Debug.LogError("DreamTimer: No timerText assigned!");
        }
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timerText != null)
            timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
            EndDream();
    }

    public void EndDream()
    {
        // Dream ended before interacting with memory
        //QuestManager.instance.dreamEndedNormally = true;

        // OPTIONAL: Freeze movement before scene load
        if (DreamMarnieMovement.instance != null)
            DreamMarnieMovement.instance.locked = true;
        
        //QuestManager.instance.currentDayState = DayState.Day;
        QuestManager.instance.currentDayState = QuestManager.DayState.Day;
        SceneManager.LoadScene("HomeScene");
    }
}
