using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int x;
    public int y;

    public PlayerData(Vector2Int gridPosition)
    {
        x = gridPosition.x;
        y = gridPosition.y;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, 0);
    }
}