using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectDatabase", menuName = "Effects/EffectDatabase")]
public class EffectDatabase : ScriptableObject
{
    public List<ItemEffect> effects;

    public static EffectDatabase _instance;
    public static EffectDatabase Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<EffectDatabase>("EffectDatabase");
            return _instance;
        }
    }


    public static ItemEffect getItemEffectByName(string name)
    {
        ItemEffect effect = Instance.effects.Find(effect => effect.name == name);
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
