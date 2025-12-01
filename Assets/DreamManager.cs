//using UnityEngine;

//public class DreamManager : MonoBehaviour
//{
    //public GameObject[] memoryObjects; 
    // index 0 = hat, 1 = bunny, 2 = book

   // void Start()
   // {
        // Hide all memories first
        //foreach (var obj in memoryObjects)
            //obj.SetActive(false);

       // int index = QuestManager.instance.currentMemoryIndex;

        // Show the correct object for tonight
       // if (index >= 0 && index < memoryObjects.Length)
            //memoryObjects[index].SetActive(true);
   // }
//}

using UnityEngine;

public class DreamManager : MonoBehaviour
{
    public GameObject hatMemory;
    public GameObject bunnyMemory;
    public GameObject bookMemory;

    void Start()
    {
        // Turn everything off first
        hatMemory.SetActive(false);
        bunnyMemory.SetActive(false);
        bookMemory.SetActive(false);

        // Which memory should appear this night?
        int i = QuestManager.instance.currentMemoryIndex;

        if (i == 0)
            hatMemory.SetActive(true);
        else if (i == 1)
            bunnyMemory.SetActive(true);
        else if (i == 2)
            bookMemory.SetActive(true);
    }
}
