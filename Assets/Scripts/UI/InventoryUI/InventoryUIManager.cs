using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{
    private VisualElement mainUI;
    private ListView myListView;

    private string[] items = { "Item 1", "Item 2", "Item 3" };

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        mainUI = root.Q<VisualElement>("root");  // Szuka elementu o name="root"
        myListView = root.Q<ListView>("InventoryListDisplay");  // Szuka ListView o name="InventoryListDisplay"

        // Inicjalizacja listy (bardzo wa¿ne, ¿eby lista mia³a dane)
        myListView.itemsSource = items;
        myListView.makeItem = () => new Label();
        myListView.bindItem = (element, index) =>
        {
            (element as Label).text = items[index];
        };

        myListView.Rebuild();

        // Na start mo¿esz ukryæ UI, jeœli chcesz:
        mainUI.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUIVisibility();
            Debug.Log("naciœniêto");
        }
    }

    private void ToggleUIVisibility()
    {
        mainUI.visible = !mainUI.visible;
        myListView.Rebuild();
        
    }
}
