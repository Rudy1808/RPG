using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{
    //Elementy UI
    private VisualElement mainUI;
    private ListView InvItemList;

    private InventoryManager inventoryManager;

    private void OnEnable()
    {
        

        //Wczytanie ekwipunku
        GameObject playerGO = GameObject.Find("Player");
        inventoryManager = playerGO.GetComponent<InventoryManager>();

        //Wczytanie i wyszukiwanie elementów UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        mainUI = root.Q<VisualElement>("root");  // Szuka elementu o name="root"
        InvItemList = root.Q<ListView>("InventoryListDisplay");  // Szuka ListView o name="InventoryListDisplay"

        InvItemList.itemsSource = inventoryManager.playerInv.InventoryList;
        InvItemList.makeItem = () => new Label();
        InvItemList.bindItem = (element, index) =>
        {
            if (inventoryManager.playerInv.InventoryList[index] == null)
            {
                (element as Label).text = "empty";
            }
            else
            {
                (element as Label).text = inventoryManager.playerInv.InventoryList[index].name;
            }
            
        };


        mainUI.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)==true)
        {
            ToggleUIVisibility();
            Debug.Log("naciœniêto");
        }
    }

    private void ToggleUIVisibility()
    {
        mainUI.visible = !mainUI.visible;

        ExampleWeapon exampleWeapon = new ExampleWeapon();
        inventoryManager.playerInv.InventoryList.Add(exampleWeapon);

        RefreshInventoryUI();
        
    }
    public void RefreshInventoryUI()
    {
        InvItemList.itemsSource = null;
        InvItemList.itemsSource = inventoryManager.playerInv.InventoryList;
        InvItemList.Rebuild();
    }
}
