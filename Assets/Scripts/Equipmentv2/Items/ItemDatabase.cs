using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Items/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Itemm> items;

    public static ItemDatabase _instance;
    public static ItemDatabase Instance 
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<ItemDatabase>("ItemDatabase");
            return _instance;
        }
    }

    public static Itemm getItemByName(string name)
    {
        Itemm item = Instance.items.Find(item => item.name == name);
        if (item == null)
            Debug.LogError("Nie znaleziono itema o nazwie {name}");
        return item;
    }
#if UNITY_EDITOR


    [ContextMenu("AutoIncrement")]
    private void AutoIncrement()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].id = i;
            EditorUtility.SetDirty(items[i]);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
