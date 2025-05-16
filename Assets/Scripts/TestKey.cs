using UnityEngine;

public class TestKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab naciœniêty");
        }
    }
}