using UnityEngine;

public class InventorySlot
{
    public Itemm item;
    public int amount;

    public bool isEmpty => item == null || amount <= 0;

    public InventorySlot(Itemm item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
