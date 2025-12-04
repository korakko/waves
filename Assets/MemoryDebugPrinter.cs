using UnityEngine;

public class MemoryDebugPrinter : MonoBehaviour
{
    void Start()
    {
        var all = FindObjectsOfType<MonoBehaviour>(); // we'll find MemoryInteract by name
        Debug.Log("=== MemoryInteract assignments ===");
        foreach (var mb in all)
        {
            var type = mb.GetType();
            if (type.Name == "MemoryInteract" || type.Name == "MemoryInteractScript" /* adjust if your class name differs */)
            {
                var mi = mb;
                // try to reflect common fields
                var t = mi.GetType();
                var memUIField = t.GetField("memoryImageUI");
                var memSpriteField = t.GetField("memorySprite");
                var memCompField = t.GetField("memoryImageComponent");

                string name = mi.gameObject.name;
                string uiName = memUIField != null && memUIField.GetValue(mi) != null ? ((Object)memUIField.GetValue(mi)).name : "NULL";
                string spriteName = memSpriteField != null && memSpriteField.GetValue(mi) != null ? ((Object)memSpriteField.GetValue(mi)).name : "NULL";
                string compName = memCompField != null && memCompField.GetValue(mi) != null ? ((Object)memCompField.GetValue(mi)).name : "NULL";

                Debug.Log($"MemoryInteract on '{name}' -> memoryImageUI = {uiName}, memoryImageComponent = {compName}, memorySprite = {spriteName}");
            }
        }
    }
}
