using Unity.Collections;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
}

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]

public abstract class Itemm : ScriptableObject
{
    [ReadOnly] public int id;
    public ItemType type;
    public new string name;
    public Sprite sprite;
    public int stackSize;
    public string description;

}
