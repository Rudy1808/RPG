using UnityEngine;

public class Slot
{
    public Itemm item;
    public int amount;

    public bool isEmpty => item == null || amount <= 0;

    public Slot(Itemm item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
