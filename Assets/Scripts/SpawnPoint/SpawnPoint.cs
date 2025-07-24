using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform player;
    [SerializeField] private int distance;

    void Update()
    {
        Vector2Int playerGridPos = Vector2Int.RoundToInt(player.position);
        Vector2Int myGridPos = Vector2Int.RoundToInt(transform.position);

        if (Mathf.Abs(playerGridPos.x - myGridPos.x) <= distance && Mathf.Abs(playerGridPos.y - myGridPos.y) <= distance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveSystem.SavePlayer(playerGridPos);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * distance * distance);
    }
}
