using UnityEngine;

public class ExampleWeapon:Weapon
{
    public ExampleWeapon()
    {
        ID = 1;
        name = "ExampleSword";
        description = "Miecz";
        atack = 15.5f;
    }
    public override void OnEquip()
    {
        Debug.Log($"{name} zosta� wyposa�ony. Atak: {atack}");
    }

    public override void OnUnequip()
    {
        Debug.Log($"{name} zosta� zdj�ty.");
    }
}
    

