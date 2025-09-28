using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //Sloty

    public int slotListLimit = 30;
    public List<Slot> slotList;

    
    public int accesoryListLimit = 3;
    public List<Slot> accesoryList;

    public Slot WeaponSlot = null;
    public Slot ArmorSlot = null;

    public Inventory()
    {
        slotList = new List<Slot>(new Slot[slotListLimit]);
        accesoryList = new List<Slot>(new Slot[accesoryListLimit]);
    }
    
    public void AddItem(Slot slotToAdd)
    {
        //je¿eli item ma stack size 1 to szukamy wolnego slotu na dodanie go
        if (slotToAdd.item.stackSize == 1)
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = slotToAdd;
                    return;
                }
            }
        }
        else
        { //je¿eli item ma stack size wiêkszy od 1 to najpierw przeszukujemy ca³a liste w celu dodania do ju¿ zajêtych przez itemy tego typu sloty i uzupe³niamy je a¿ wyczerpiemy wszystkie itemy.

            for (int i = 0; i < slotList.Count; i++)
            {
               
                if (slotList[i] != null && slotList[i].item.name == slotToAdd.item.name)
                {
                    while(slotList[i].amount <= slotToAdd.item.stackSize)
                    {
                        slotList[i].amount++;
                        slotToAdd.amount--;
                        if(slotToAdd.amount == 0)
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
                    slotList[i] = slotToAdd;
                    return;
                }
            }
        }
        //je¿eli nie uda³o siê dodaæ itemu to... nie wiem co. na przysz³oœæ mo¿na zmieniæ metode na typ bool i obs³u¿yæ nieuzupe³nienie slota z zewn¹trz.
        Debug.Log($"Nie uda³o siê dodaæ itema o nazwie {slotToAdd.item.name} (iloœæ niedodanwgo itema to: {slotToAdd.amount})");
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
                    slotList[i] = new Slot(itemToAdd, 1);
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
                    while (slotList[i].amount < itemToAdd.stackSize)
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
                        slotList[i] = new Slot(itemToAdd, itemToAdd.stackSize);
                        amount -= itemToAdd.stackSize;
                    }
                    else
                    {
                        slotList[i] = new Slot(itemToAdd, amount);
                        return;
                    }
                }
                if (amount == 0)
                {
                    return;
                }
            }
        }
        Debug.Log($"Nie uda³o siê dodaæ itema o nazwie {itemToAdd.name} (iloœæ niedodanwgo itema to: {amount}).");
    }
    public void AddItem(Itemm itemToAdd)
    {
        if (itemToAdd.stackSize == 1)
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = new Slot(itemToAdd, 1);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] != null && slotList[i].item.name == itemToAdd.name && slotList[i].amount < itemToAdd.stackSize)
                {
                    slotList[i].amount++;
                    return;
                }
            }
            for (int i = 0; i < slotList.Count; i++)
            {
                if (slotList[i] == null)
                {
                    slotList[i] = new Slot(itemToAdd, 1);
                    return;
                }
            }
        }
        Debug.Log($"Nie uda³o siê dodaæ itema o nazwie: {itemToAdd.name}.");
    }

    public void RemoveItem(Slot item)
    {
        slotList.Remove(item);
    }
    public void DescribeInventory()
    {
        foreach(Slot item in slotList)
        {
            if(item != null)
            Debug.Log($"nazwa: {item.item.name}, iloœæ: {item.amount}");
        }
    }
    private void Start()
    {

        Slot slot = new Slot(ItemDatabase.getItemByName("Apple"), 4);
        AddItem(slot);
        AddItem(ItemDatabase.getItemByName("Apple"), 120);
        AddItem(ItemDatabase.getItemByName("Apple"));
        AddItem(ItemDatabase.getItemByName("Apple"));
        AddItem(ItemDatabase.getItemByName("Apple"));
        AddItem(ItemDatabase.getItemByName("Apple"));
        AddItem(ItemDatabase.getItemByName("Apple"));
        DescribeInventory();
    }
}
