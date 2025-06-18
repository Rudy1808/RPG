using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{
    public UIDocument UI;

    private void Start()
    {
        Scaling();
    }
    private void Scaling()
    {
        int width = 640;
        int height = 360;

        int scalingValue = Mathf.Min(Screen.width / width, Screen.height / height);
        
        if (scalingValue < 1)
        {
            return;
        }
        var root = UI.rootVisualElement;

        root.style.width = width * scalingValue;
        root.style.height = height * scalingValue;

    }
}
