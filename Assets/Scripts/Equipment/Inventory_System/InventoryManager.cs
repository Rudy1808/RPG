using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory playerInv;

    private void Awake()
    {
        playerInv = new Inventory();
    }
    void Start()
    {

        ExampleWeapon exampleWeapon1 = new ExampleWeapon();    
        ExampleWeapon exampleWeapon2 = new ExampleWeapon();
        exampleWeapon2.name = "ExampleWeapon2";
        ExampleArmor exampleArmor = new ExampleArmor();

        playerInv.AddItem(exampleArmor);
        playerInv.AddItem(exampleWeapon1);
        playerInv.AddItem(exampleWeapon2);

        Item item1 = new Item();
        Item item2 = new Item();
        Item item3 = new Item();

        item1.name = "item";
        item2.name = "item";
        item3.name = "item";

        playerInv.AddItem(item1);
        playerInv.AddItem(item2);
        playerInv.AddItem(item3);

        playerInv.EquipArmor(0);
        playerInv.EquipWeapon(0);

    }
}
