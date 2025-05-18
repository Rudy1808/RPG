using UnityEngine;

public class ExampleWeapon:Weapon
{
    public ExampleWeapon()
    {
        ID = 1;
        name = "ExampleSword";
        description = "Miecz";
        atack = 0f;
    }
    public override void OnEquip()
    {
        Debug.Log($"{name} zosta³ wyposa¿ony. Atak: {atack}");
    }

    public override void OnUnequip()
    {
        Debug.Log($"{name} zosta³ zdjêty.");
    }
}
    

