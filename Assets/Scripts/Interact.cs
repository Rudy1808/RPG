using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 2f;
    [SerializeField] private string description = "";

    void Update()
    {
        if (!string.IsNullOrEmpty(description))
        {
            if (Mathf.Abs(player.position.x - transform.position.x) <= distance && Mathf.Abs(player.position.y - transform.position.y) <= distance)
            {
                if (Input.GetKeyDown(KeyCode.E)) //&& UI jest wy³¹czone
                {
                    Debug.Log(description);
                    // w³¹czenie UI


                }
                //if UI jest w³czone i kliknie E to wy³¹cz UI
            }
            else // if UI jest w³¹czone
            {
                // wy³acz UI 
            }
        }
    }
}