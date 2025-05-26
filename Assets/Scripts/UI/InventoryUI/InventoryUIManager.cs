using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{
    //Elementy UI
    private VisualElement mainUI;
    private ListView InvItemList;
    private Label ArmorDisplay;
    private Label WeaponDisplay;

    private InventoryManager inventoryManager;
    private PlayerMovement playerMovement;

    private void Start()
    {
        
        initializeUI();

        //Lista przdmiotów
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

        InvItemList.selectedIndex = 0;

        mainUI.visible = false;

        Refresh();
    }

    private void Update()
    {
        //Wyœwietlenie
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            ToggleUIVisibility();
        }

        ////Sterowanie
        //    //Strza³ka w dó³
        //if (Input.GetKeyDown(KeyCode.S) == true)
        //{
        //    // wybrany index = (wybrany index ++) % D³ugoœ listy
        //    InvItemList.selectedIndex = Mathf.Clamp(InvItemList.selectedIndex+1, 0, InvItemList.itemsSource.Count - 1);
        //}

        //    //Strza³ka w góre
        //if (Input.GetKeyDown(KeyCode.W) == true)
        //{
        //    // wybrany index = (wybrany index ++) % D³ugoœ listy
        //    InvItemList.selectedIndex = Mathf.Clamp(InvItemList.selectedIndex-1, 0, InvItemList.itemsSource.Count - 1);

        //}
            //Wybranie przedmiotu
        if (Input.GetKeyDown(KeyCode.Z) == true)
        {
            if (inventoryManager.playerInv.InventoryList[InvItemList.selectedIndex] is Weapon)
            {
                inventoryManager.playerInv.EquipWeapon(InvItemList.selectedIndex);
                Refresh();
            }
        }

        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            inventoryManager.playerInv.RemoveItem(InvItemList.selectedIndex);
            Refresh();
        }


    }

    private void ToggleUIVisibility()
    {
        mainUI.visible = !mainUI.visible;
        playerMovement.enabled = !playerMovement.enabled;
        Refresh();
    }
    private void Refresh()
    {
        var inv = inventoryManager.playerInv;

        WeaponDisplay.text = inv.weaponSlot != null
            ? $"Weapon : {inv.weaponSlot.name}"
            : "Weapon : empty";

        ArmorDisplay.text = inv.armorSlot != null
            ? $"Armor : {inv.armorSlot.name}"
            : "Armor : empty";

        InvItemList.Rebuild();
    }

    private void initializeUI()
    {
        //Wczytanie i sprawdzenie czy gracz istnieje
        GameObject playerGO = GameObject.Find("Player");
        if (playerGO == null)
        {
            Debug.LogError("Nie znaleziono GameObject 'Player'");
            return;
        }

        //sprawdzenie czy inventoryManager istnieje w playerze
        inventoryManager = playerGO?.GetComponent<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("Brak komponentu InventoryManager na obiekcie Player");
            return;
        }

        playerMovement = playerGO.GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("Brak komponentu PlayerMovement na obiekcie Player");
            return;
        }

        //Dodatkowe sprawdznie czy gracz ma utworzony ekwipunek
        if (inventoryManager.playerInv == null)
        {
            Debug.LogError("playerInv jest null");
            return;
        }

        //Wczytanie i wyszukiwanie elementów UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        mainUI = root?.Q<VisualElement>("root");  // Szuka elementu o name="root"
        InvItemList = root?.Q<ListView>("InventoryListDisplay");  // Szuka ListView o name="InventoryListDisplay"
        ArmorDisplay = root?.Q<Label>("ArmorDisplay");
        WeaponDisplay = root?.Q<Label>("WeaponDisplay");
    }

}
