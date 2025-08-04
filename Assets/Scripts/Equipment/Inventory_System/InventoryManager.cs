using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventoryy playerInv;

    private void Awake()
    {
        playerInv = new Inventoryy();

        ExampleArmor armor = new ExampleArmor();

        playerInv.AddItem(armor);

        ExampleWeapon weapon = new ExampleWeapon();

        playerInv.AddItem(weapon);
    }
    void Start()
    {

        
       
    }
}
