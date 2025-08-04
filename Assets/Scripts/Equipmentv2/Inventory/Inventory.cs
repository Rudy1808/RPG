using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    //Sloty

    public int slotListLimit = 30;
    public List<Slot> slotList = new List<Slot>();

    public int accesoryListLimit = 3;
    public List<Slot> accesoryList = new List<Slot>();

    public Slot WeaponSlot;
    public Slot ArmorSlot;

    public void AddItem(Slot item)
    {
        if(slotList.Count < 30)
        {
            slotList.Add(item);
        }
    }
    public void RemoveItem(Slot item)
    {
        slotList.Remove(item);
    }

    private void Start()
    {
        Slot slot = new Slot();
        slot.Amount = 1;
        AddItem(slot);
    }


}
