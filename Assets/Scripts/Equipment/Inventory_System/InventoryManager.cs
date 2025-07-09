using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory playerInv;

    private void Awake()
    {
        playerInv = new Inventory();
        for (int i=0; i < 10; i++)
        {
            TestItem testItem = new TestItem();

            playerInv.AddItem(testItem);
        }
    }
    void Start()
    {

        
       
    }
}
