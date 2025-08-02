using System.ComponentModel;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Weapon,
    Armor
}

public abstract class Itemm : ScriptableObject
{
    public int id;
    public new string name;
    public Sprite sprite;
    public int stackSize;
    public string description;
    public abstract ItemType type { get; }

}
