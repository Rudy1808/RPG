using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor")]
public class Armorr:Itemm
{
    public override ItemType type => ItemType.Armor;
    public float defence;
}
