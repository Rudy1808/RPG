using UnityEngine;
using UnityEngine.UIElements;

public class UIScaling : MonoBehaviour
{
    private UIDocument uiDocument;
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        Scalling();
    }
    private void Scalling()
    {
        var root = uiDocument.rootVisualElement;
        root.style.scale = new Vector2(2f, 2f);

    }

}
