using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 2f;

    void Update()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) <= distance && Mathf.Abs(player.position.y - transform.position.y) <= distance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveSystem.SavePlayer(Vector2Int.RoundToInt(player.position));
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * distance * distance);
    }
}
