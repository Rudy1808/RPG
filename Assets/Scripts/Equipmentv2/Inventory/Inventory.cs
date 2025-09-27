using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //Sloty

    public int slotListLimit = 30;
    public List<InventorySlot> slotList;

    
    public int accesoryListLimit = 3;
    public List<InventorySlot> accesoryList;

    public InventorySlot WeaponSlot = null;
    public InventorySlot ArmorSlot = null;

    public Inventory()
    {
        slotList = new List<InventorySlot>(new InventorySlot[slotListLimit]);
        accesoryList = new List<InventorySlot>(new InventorySlot[accesoryListLimit]);
    }
    
    public void AddItem(InventorySlot itemToAdd)
    {
        //je¿eli item ma stack size 1 to szukamy wolnego slotu na dodanie go
        if (itemToAdd.item.stackSize == 1)
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = itemToAdd;
                    return;
                }
            }
        }
        else
        { //je¿eli item ma stack size wiêkszy od 1 to najpierw przeszukujemy ca³a liste w celu dodania do ju¿ zajêtych przez itemy tego typu sloty i uzupe³niamy je a¿ wyczerpiemy wszystkie itemy.

            for (int i = 0; i < slotList.Count; i++)
            {
               
                if (slotList[i] != null && slotList[i].item.name == itemToAdd.item.name)
                {
                    while(slotList[i].amount <= itemToAdd.item.stackSize)
                    {
                        slotList[i].amount++;
                        itemToAdd.amount--;
                        if(itemToAdd.amount == 0)
                        {
                            return;
                        }
                    }
                }
            }//je¿eli nie znajdziemy slotów zajêtych przez nasz item lub wszystkie sloty siê zape³ni¹ to znajdujemy pusty slot
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = itemToAdd;
                    return;
                }
            }
        }
        //je¿eli nie uda³o siê dodaæ itemu to... nie wiem co. na przysz³oœæ mo¿na zmieniæ metode na typ bool i obs³u¿yæ nieuzupe³nienie slota z zewn¹trz.
        Debug.Log($"Nie uda³o siê dodaæ itema. (iloœæ niedodanwgo itema to: {itemToAdd.amount})");
    }

    //przeci¹¿enie funkcji. pozwala na dodawanie itemów z poza slotów (skrzyñ) np. podnoszenie z ziemi lub kupowanie.
    //Pozwala na dodawanie wiêcej ni¿ jeden stack!
    public void AddItem(Itemm itemToAdd, int amount)
    {
        if (itemToAdd.stackSize == 1)
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = new InventorySlot(itemToAdd, 1);
                    amount--;
                }
                if (amount == 0)
                {
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < slotList.Count; i++)
            {

                if (slotList[i] != null && slotList[i].item.name == itemToAdd.name)
                {
                    while (slotList[i].amount <= itemToAdd.stackSize)
                    {
                        slotList[i].amount++;
                        amount--;
                        if (amount == 0)
                        {
                            return;
                        }
                    }
                }
            }
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    if (itemToAdd.stackSize <= amount)
                    {
                        slotList[i] = new InventorySlot(itemToAdd, itemToAdd.stackSize);
                        amount -= itemToAdd.stackSize;
                    }
                    else
                    {
                        slotList[i] = new InventorySlot(itemToAdd, amount);
                        return;
                    }
                }
                if (amount == 0)
                {
                    return;
                }
            }
        }
        Debug.Log($"Nie uda³o siê dodaæ itema. (iloœæ niedodanwgo itema to: {amount})");
    }

    public void RemoveItem(InventorySlot item)
    {
        slotList.Remove(item);
    }
    public void DescribeInventory()
    {
        foreach(InventorySlot item in slotList)
        {
            if(item != null)
            Debug.Log(item.item.name);
        }
    }
    private void Start()
    {

        //InventorySlot slot = new InventorySlot(ItemDatabase.getItemByName("Apple"), 5);
        AddItem(ItemDatabase.getItemByName("Apple"), 120);
        DescribeInventory();
    }
}
