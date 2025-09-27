using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Items/Consumable")]

public class Consumable : Itemm
{
    public List<ItemEffect> effects;
    public void Use(GameObject target)
    {
        foreach (var effect in effects)
        {
            effect.ApplyEffect(target);
        }
    }
}
