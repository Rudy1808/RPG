using UnityEngine;
using UnityEngine.UIElements;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 2f;
    [SerializeField] private string description = "";

    //UI
    public GameObject uiGO;
    public UIDocument uiDocument;
    private VisualElement root;
    private Label label;

    void ElementLoad()
    {
        uiGO = GameObject.Find("InteractUI");

        if (uiGO == null)
        {
            Debug.LogError("Brak gameobjectu InteractUI");
        }

        uiDocument = uiGO.GetComponent<UIDocument>();

        if (uiDocument == null)
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

        label = root.Q<Label>("interact-text");

        if (label == null)
        {
            Debug.LogError("Nie znaleziono elementu 'interact-text' w UI");
        }
            
    }

    private void Awake()
    {
        ElementLoad();
        root.style.visibility = Visibility.Hidden;
    }
    void Update()
    {
        if (!string.IsNullOrEmpty(description))
        {
            if (Mathf.Abs(player.position.x - transform.position.x) <= distance && Mathf.Abs(player.position.y - transform.position.y) <= distance)
            {
                if (Input.GetKeyDown(KeyCode.E)&&root.style.visibility == Visibility.Hidden) 
                {
                    label.text = description;
                    root.style.visibility = Visibility.Visible;
                }
                else if (root.style.visibility == Visibility.Visible && Input.GetKeyDown(KeyCode.E))
                {
                    root.style.visibility = Visibility.Hidden;
                }
            }
            else if(root.style.visibility == Visibility.Visible)
            {
                root.style.visibility = Visibility.Hidden;
            }
        }
    }
}