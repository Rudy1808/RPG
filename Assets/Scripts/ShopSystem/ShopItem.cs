using UnityEngine;

public class ShopItem : Item
{
    public int Id;
    //ItemDatabase.GetItemByID(ID);
    public int Price {  get; private set; }
    public float PriceModifier = 1f;
}
