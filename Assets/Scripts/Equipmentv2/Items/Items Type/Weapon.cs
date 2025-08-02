using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]

public class Weaponn : Itemm
{
    public override ItemType type => ItemType.Weapon;
    public float attack;
}