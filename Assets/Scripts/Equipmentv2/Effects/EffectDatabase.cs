using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectDatabase", menuName = "Effects/EffectDatabase")]
public class EffectDatabase : ScriptableObject
{
    public ItemEffect[] effects;
#if UNITY_EDITOR
    [ContextMenu("AutoIncrement")]
    private void AutoIncrement()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].id = i;
            EditorUtility.SetDirty(effects[i]);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
