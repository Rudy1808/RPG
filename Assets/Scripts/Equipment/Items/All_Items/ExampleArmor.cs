using UnityEngine;

public class ExampleArmor:Armor
{
    public ExampleArmor()
    {
        ID = 1;
        name = "ExampleArmor";
        description = "Zbroja";
        def = 0f;
    }
    public override void OnEquip()
    {
        Debug.Log($"{name} zosta³ wyposa¿onu. Obrona: {def}");
    }

    public override void OnUnequip()
    {
        Debug.Log($"{name} zosta³ zdjêty.");
    }
}
