using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Collections;

public class UIscript : MonoBehaviour
{
    //Grid
    [SerializeField] private int gridRow = 6;
    [SerializeField] private int gridColumn = 5;
    private List<VisualElement> slotList = new List<VisualElement>();
    private VisualElement selectedSlot;

    private enum SelectionMoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }


    //elementy UI
    public UIDocument uiDocument;
    private VisualElement slotGrid;
    private VisualElement root;
    private Label nameLabel;
    private Label descriptionLabel;

    //Logika inventory
    private InventoryManager inventory;

    private void Awake()
    {
        ElementLoad();
    }

    void Start()
    {
        CreateSlotGrid();
        root.style.visibility = Visibility.Hidden;
        SelectSlot(0);
        LoadIcons();
    }

    // Update is called once per frame
    void Update()
    {
        // Prze³¹cz widocznoœæ C
        if (Input.GetKeyDown(KeyCode.C))
        {

            ToggleUI();
        }

        //Equipowanie Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EquipSelectedSlot();
        }

        // Poruszanie siê po gridzie
        if (Input.GetKeyDown(KeyCode.UpArrow)) SelectionMove(SelectionMoveDirection.Up);
        if (Input.GetKeyDown(KeyCode.DownArrow)) SelectionMove(SelectionMoveDirection.Down);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) SelectionMove(SelectionMoveDirection.Left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) SelectionMove(SelectionMoveDirection.Right);
    }
    void Refresh()
    {
        //Clearujemy wszystkie bagroundy w UI
        for (int i = 0; i < gridColumn * gridRow; i++)
        {
            slotList[i].Q(className: "slot-icon").style.backgroundImage = null;
        }

        //£adujemy Icony do UI spowrotem
        LoadIcons();
    }
    void ToggleUI()
    {
        if (root.style.visibility == Visibility.Hidden)
        {
            root.style.visibility = Visibility.Visible;
        }
        else
        {
            root.style.visibility = Visibility.Hidden;
        }
        Refresh();
    }
    void CreateSlotGrid()
    {
        for (int i = 0; i <gridColumn*gridRow; i++)
        {
            VisualElement slot = new VisualElement();
            VisualElement icon = new VisualElement();
            VisualElement frame = new VisualElement();
            slot.AddToClassList("slot");
            icon.AddToClassList("slot-icon");
            frame.AddToClassList("slot-frame");
            slotGrid.Add(slot);
            slot.Add(icon);
            slot.Add(frame);
            slotList.Add(slot);
        }
    }
    void LoadIcons()
    {
        var inv = inventory.playerInv;
        for (int i = 0; i < inv.ItemList.Count; i++)
        {
            slotList[i].Q(className: "slot-icon").style.backgroundImage = new StyleBackground(inv.ItemList[i].Icon);
        }
    }
    void ElementLoad()
    {
        //UI
        if(uiDocument == null)
        {
            Debug.LogError("Brak przypisanego UIDocument!");
            return;
        }

        root = uiDocument.rootVisualElement;

        if (root == null)
        {
            Debug.LogError("uiDocument.rootVisualElement zwróci³ null!");
            return;
        }

        slotGrid = root.Q<VisualElement>("slot-grid");

        if (slotGrid == null)
        {
            Debug.LogError("Nie znaleziono elementu 'slot-grid' w UI"   );
            return;
        }

        nameLabel = root.Q<Label>("label-name");
        if (nameLabel == null)
        {
            Debug.LogError("Nie znaleziono elementu 'label-name' w UI");
            return;
        }

        descriptionLabel = root.Q<Label>("label-description");
        if (descriptionLabel == null)
        {
            Debug.LogError("Nie znaleziono elementu 'label-description' w UI");
            return;
        }

        //Skrypty
        GameObject player = GameObject.Find("Player");
        inventory = player.GetComponent<InventoryManager>();

        if (inventory == null)
        {
            Debug.LogError("Nie znaleziono inventory manager");
            return;
        }

    }
    void EquipSelectedSlot()
    {
        var inv = inventory.playerInv;
        int index = slotList.IndexOf(selectedSlot);

        // SprawdŸ, czy indeks jest w zakresie listy itemów
        if (index < 0 || index >= inv.ItemList.Count)
        {
            return;
        }

        var item = inv.ItemList[index];

        if (item is Weapon)
        {
            inv.EquipWeapon(index);
        }
        else if (item is Armor)
        {
            inv.EquipArmor(index);
        }

        Refresh();
    }
    void SelectSlot(int index)
    {
        if (selectedSlot != null)
            selectedSlot.RemoveFromClassList("selected-slot");
            if (index >= 0 && index < inventory.playerInv.ItemList.Count)
            {
                nameLabel.text = inventory.playerInv.ItemList[index].name;
                descriptionLabel.text = inventory.playerInv.ItemList[index].description;
            }
            else
            {
                nameLabel.text = "";
                descriptionLabel.text = "";
            }

        selectedSlot = slotList[index];
        selectedSlot.AddToClassList("selected-slot");



    }
    void SelectionMove(SelectionMoveDirection direction)
    {
        var index = slotList.IndexOf(selectedSlot);
        switch (direction)
        {
            case SelectionMoveDirection.Up:
                if ((index - gridRow) >= 0)
                    SelectSlot(index - gridRow);
                break;

            case SelectionMoveDirection.Down:
                if((index+gridRow) < slotList.Count)
                    SelectSlot(index+gridRow);
                break;

            case SelectionMoveDirection.Left:
                if (index-1 >= 0)
                    SelectSlot(index - 1);       
                break;

            case SelectionMoveDirection.Right:
                if (index + 1 < slotList.Count)
                        SelectSlot(index+1);
                break;
        }
    }
}
