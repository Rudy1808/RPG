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
        ExampleArmor exampleArmor = new ExampleArmor();

        playerInv.AddItem(exampleArmor);
        playerInv.AddItem(exampleWeapon1);


        playerInv.EquipArmor(0);
        playerInv.EquipWeapon(0);

    }
}
