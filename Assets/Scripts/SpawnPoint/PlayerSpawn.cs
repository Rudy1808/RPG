using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        Vector3? savedPos = SaveSystem.LoadPlayer();
        if (savedPos != null)
        {
            transform.position = savedPos.Value;
            Debug.Log("Wczytano pozycjê gracza: " + savedPos);
        }
    }
}