using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> InventoryList = new List<Item>();
    private int inventoryLimit = 10;
    private Weapon weaponSlot;
    private Armor armorSlot;
    private Accesory accesorySlot1;
    private Accesory accesorySlot2;
    private Accesory accesorySlot3;

    public void AddItem(Item item)
    {
        if (InventoryList.Count < inventoryLimit)
        {
            InventoryList.Add(item);
        }
        else
        {
            Debug.Log("Inventory Full");
        }
    }
    public void RemoveItem(Item item)
    {
        InventoryList.Remove(item);
    }
    public void EquipWeapon(int itemNumber)
    {
        if (InventoryList[itemNumber] is Weapon weapon)
        {
            weaponSlot = weapon;
            InventoryList.RemoveAt(itemNumber);
        }
        else
        {
            Debug.Log("To nie bron");
        }
    }
    public void EquipArmor(int itemNumber)
    {
        if (InventoryList[itemNumber] is Armor armor)
        {
            armorSlot = armor;
            InventoryList.RemoveAt(itemNumber);
        }
        else
        {
            Debug.Log("To nie armor");
        }
    }
    public void EquipAccesory(int itemNumber, int slotNumber)
    {
        if (InventoryList[itemNumber] is Accesory accesory)
        {
            switch (slotNumber)
            {
                case 1:
                    {
                        accesorySlot1 = accesory;
                        InventoryList.RemoveAt(itemNumber);
                        break;
                    }
                case 2:
                    {
                        accesorySlot2 = accesory;
                        InventoryList.RemoveAt(itemNumber);
                        break;
                    }
                case 3:
                    {
                        accesorySlot3 = accesory;
                        InventoryList.RemoveAt(itemNumber);
                        break;
                    }
                default:
                    {
                        Debug.Log("Zly slot");
                        break;
                    }

            }
        }
        else
        {
            Debug.Log("To nie accesory");
        }
    }
    public void DescribeInventory()
    {
        Debug.Log($"Weapon : {weaponSlot.name}");
        Debug.Log($"Armor : {armorSlot.name}");
        Debug.Log($"Accesory1 {accesorySlot1.name}");
        Debug.Log($"Accesory2 {accesorySlot2.name}");
        Debug.Log($"Accesory3 {accesorySlot3.name}");
        Debug.Log("InventoryList : ");

        foreach (Item item in InventoryList)
        {
            Debug.Log(item.name);
        }
    }
}
