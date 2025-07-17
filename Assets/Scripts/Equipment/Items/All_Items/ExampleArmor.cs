using UnityEngine;

public class ExampleArmor:Armor
{
    public ExampleArmor()
    {
        ID = 1;
        name = "ExampleArmor";
        description = "";
        def = 0f;
        Icon = Resources.Load<Texture2D>("itemIcons/TestItemIcon");
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
