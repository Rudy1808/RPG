using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
    }
    void Start()
    {
        ExampleWeapon ExampleWeapon = new ExampleWeapon();
        inventory.AddItem(ExampleWeapon);
        inventory.DescribeInventory();
        inventory.EquipWeapon(0);
        inventory.DescribeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
