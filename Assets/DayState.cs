using UnityEngine;
public enum DayState { Day, Night }

public class DayStateManager : MonoBehaviour
{
    public DayState currentState = DayState.Day;
    
    public void SetDayState(DayState newState)
    {
        currentState = newState;
        Debug.Log("Day state changed to: " + newState);
    }
    
    public void SetToNight()
    {
        SetDayState(DayState.Night);
    }
    
    public void SetToDay()
    {
        SetDayState(DayState.Day);
    }
}
