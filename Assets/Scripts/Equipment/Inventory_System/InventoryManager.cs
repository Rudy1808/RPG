using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory playerInv;

    private void Awake()
    {
        playerInv = new Inventory();

        ExampleArmor armor = new ExampleArmor();

        playerInv.AddItem(armor);

        ExampleWeapon weapon = new ExampleWeapon();

        playerInv.AddItem(weapon);
    }
    void Start()
    {

        
       
    }
}
