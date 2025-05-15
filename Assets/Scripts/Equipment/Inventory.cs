using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> InventoryList = new List<Item>();
    static private int inventoryLimit = 10;
    static private int accesoryLimit = 3;
    private Weapon weaponSlot;
    private Armor armorSlot;
    private Accesory[] AcessoryList = new Accesory[accesoryLimit];

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
        //sprawdzenie zgodnoœci indeksu
        if (itemNumber < 0 || itemNumber >= InventoryList.Count)
        {
            Debug.Log("Nieprawid³owy indeks");
            return;
        }

        if (InventoryList[itemNumber] is Weapon weapon)
        {
            // Usuwamy now¹ broñ z listy
            InventoryList.RemoveAt(itemNumber);

            // Zmienna pomocnicza na star¹ broñ
            Weapon oldWeapon = weaponSlot;

            // Przypisujemy i aktywujemy now¹ broñ
            weaponSlot = weapon;
            weaponSlot.OnEquip();

            // Jeœli by³ stara broñ zdejmujemy j¹ i dodajemy do ekwipunku
            if (oldWeapon != null)
            {
                oldWeapon.OnUnequip();
                AddItem(oldWeapon);
            }
        }
        else
        {
            Debug.Log("To nie armor");
            return;
        }
    }
    public void UnequipWeapon()
    {
        if(weaponSlot != null)
        {
            if (InventoryList.Count < inventoryLimit)
            {
                AddItem(weaponSlot);
                weaponSlot=null;
            }
            else
            {
                Debug.Log("Pe³ny ekwipunek");
            }
        }
        else
        {
            Debug.Log("Slot pusty podczas unequipowania");
        }
    }
    public void EquipArmor(int itemNumber)
    {
        //sprawdzenie zgodnoœci indeksu
        if (itemNumber < 0 || itemNumber >= InventoryList.Count)
        {
            Debug.Log("Nieprawid³owy indeks");
            return;
        }

        if (InventoryList[itemNumber] is Armor armor)
        {
            // Usuwamy nowy pancerz z listy
            InventoryList.RemoveAt(itemNumber);

            // Zmienna pomocnicza na stary pancerz
            Armor oldArmor = armorSlot;

            // Przypisujemy i aktywujemy nowy pancerz
            armorSlot = armor;
            armorSlot.OnEquip();

            // Jeœli by³ stary pancerz, zdejmujemy go i dodajemy do ekwipunku
            if (oldArmor != null)
            {
                oldArmor.OnUnequip();
                AddItem(oldArmor);
            }
        }
        else
        {
            Debug.Log("To nie armor");
            return;
        }
    }
    public void UnequipArmor()
    {
        if (armorSlot != null)
        {
            if (InventoryList.Count < inventoryLimit)
            {
                AddItem(armorSlot);
                armorSlot = null;
            }
            else
            {
                Debug.Log("Pe³ny ekwipunek");
            }
        }
        else
        {
            Debug.Log("Slot pusty podczas unequipowania");
        }
    }
    public void EquipAccesory(int itemNumber, int slotNumber)
    {
        //sprawdzenie zgodnoœci indeksu
        if (itemNumber < 0 || itemNumber >= InventoryList.Count)
        {
            Debug.Log("Nieprawid³owy indeks");
            return;
        }

        //sprawdzenie zgodnoœci numeru slotu
        if (slotNumber < 0 || slotNumber >= accesoryLimit)
        {
            Debug.Log("Nieprawid³owy numer slotu akcesoriów");
            return;
        }


        if (InventoryList[itemNumber] is Accesory accesory)
        {
            //Usuwanie akcesoria z listy
            InventoryList.RemoveAt(itemNumber);

            //Zapisanie starego akcesoria w liœcie pomocniczej
            Accesory oldAccessory = AcessoryList[slotNumber];

            //Zapisanie accesoria w slocie i wywa³anie funkcji equip
            AcessoryList[slotNumber] = accesory;
            AcessoryList[slotNumber].OnEquip();

            if (oldAccessory != null)
            {
                oldAccessory.OnUnequip();
                AddItem(oldAccessory);
            }
        }
        else
        {
            Debug.Log("To nie accesory");
        }
    }
    public void UnequipAccesory(int slotNumber)
    {
        if (AcessoryList[slotNumber] != null)
        {
            if (InventoryList.Count < inventoryLimit)
            {
                AddItem(AcessoryList[slotNumber]);
                AcessoryList[slotNumber] = null;
            }
            else
            {
                Debug.Log("Pe³ny ekwipunek");
            }
        }
        else
        {
            Debug.Log("Slot pusty podczas unequipowania");
        }
    }
    public void DescribeInventory()
    {
        Debug.Log($"Weapon : {weaponSlot.name}");
        Debug.Log($"Armor : {armorSlot.name}");
        Debug.Log($"Accesory1 {AcessoryList[0].name}");
        Debug.Log($"Accesory2 {AcessoryList[1].name}");
        Debug.Log($"Accesory3 {AcessoryList[2].name}");
        Debug.Log("InventoryList : ");

        foreach (Item item in InventoryList)
        {
            Debug.Log(item.name);
        }
    }
}
