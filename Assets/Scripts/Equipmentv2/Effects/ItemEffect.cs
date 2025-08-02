using UnityEngine;

public abstract class ItemEffect : ScriptableObject
{
    public int id;
    public abstract void ApplyEffect(GameObject target);
}
