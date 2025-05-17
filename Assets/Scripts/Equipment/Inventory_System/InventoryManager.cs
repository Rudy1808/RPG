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
        ExampleWeapon exampleWeapon = new ExampleWeapon();
        playerInv.AddItem(exampleWeapon);
        
    }
}
