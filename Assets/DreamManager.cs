using UnityEngine;

public class DreamManager : MonoBehaviour
{
    public GameObject hatMemory;
    public GameObject bunnyMemory;
    public GameObject bookMemory;

    void Start()
    {
        hatMemory.SetActive(false);
        bunnyMemory.SetActive(false);
        bookMemory.SetActive(false);

        int i = QuestManager.instance.currentMemoryIndex;

        if (i == 0) hatMemory.SetActive(true);
        else if (i == 1) bunnyMemory.SetActive(true);
        else if (i == 2) bookMemory.SetActive(true);
    }
}


//using UnityEngine;

//public class DreamManager : MonoBehaviour{
    //public GameObject hatMemory;
    //public GameObject bunnyMemory;
    //public GameObject bookMemory;

    //void Start()
    //{
        // Turn everything off first
        ///hatMemory.SetActive(false);
        //bunnyMemory.SetActive(false);
        //bookMemory.SetActive(false);

        // Which memory should appear this night?
        //int i = QuestManager.instance.currentMemoryIndex;

        //if (i == 0) 
            //hatMemory.SetActive(true);
        //else if (i == 1)
            //bunnyMemory.SetActive(true);
        //else if (i == 2)
            //bookMemory.SetActive(true);
   //}}
