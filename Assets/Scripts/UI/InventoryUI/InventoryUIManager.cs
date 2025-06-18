using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{

    //elementy
    public VisualElement root;
    public VisualElement inventoryGrid;

    //scalowanie
    public int baseWidth = 640;
    public int baseHeigh = 360;

    public int scaleX;
    public int scaleY;
    public int scaleFactor;

    private List<VisualElement> slotList = new List<VisualElement>();
    private int slotNumber = 28;
    private void Start()
    {
        InitializeUI();
        BuildInventoryGrid();
        ScalingUI();

    }
    private void InitializeUI()
    {
        root = GetComponent<UIDocument>()?.rootVisualElement;
        inventoryGrid = root.Q<VisualElement>("InventoryGrid");

        if (inventoryGrid == null)
        {
            Debug.LogError("Brak VisualElement o nazwie 'InventoryGrid'");
        }
    }
    private void ScalingUI()
    {
        scaleX = Screen.width / baseWidth;
        scaleY = Screen.height / baseHeigh;

        scaleFactor = math.min(scaleX, scaleY);

        root.style.width = baseWidth;
        root.style.height = baseHeigh;
        root.style.scale = new Scale(new Vector2(scaleFactor,scaleFactor));

    }
    private void BuildInventoryGrid()
    {
        for (int i = 0; i < slotNumber; i++)
        {
            var slot = new VisualElement();
            slot.AddToClassList("slot");
            inventoryGrid.Add(slot);
            slotList.Add(slot);
        }
    }
    private void Refresh()
    {

    }
}
