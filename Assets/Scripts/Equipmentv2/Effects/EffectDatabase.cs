using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectDatabase", menuName = "Effects/EffectDatabase")]
public class EffectDatabase : ScriptableObject
{
    public static List<ItemEffect> effects;
    


    public static ItemEffect getItemEffectByName(string name)
    {
        ItemEffect effect = effects.Find(effect => effect.name == name);
        if (effect == null)
            Debug.LogError("Nie znaleziono efektu o nazwie {name}");
        return effect;
    }

#if UNITY_EDITOR
    [ContextMenu("AutoIncrement")]
    private void AutoIncrement()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].id = i;
            EditorUtility.SetDirty(effects[i]);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
