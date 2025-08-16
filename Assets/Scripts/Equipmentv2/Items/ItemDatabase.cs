using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Items/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public static List<Itemm> items;

    public static Itemm getItemByName(string name)
    {
        return items.Find(item => item.name == name);
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
