using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string savePath => Application.persistentDataPath + "/playerdata.json";

    public static void SavePlayer(Vector2Int gridPosition)
    {
        var data = new PlayerData(gridPosition);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Pozycja zapisana: " + gridPosition);
    }

    public static Vector3? LoadPlayer()
    {
        if (!File.Exists(savePath)) return null;

        string json = File.ReadAllText(savePath);
        var data = JsonUtility.FromJson<PlayerData>(json);
        return data.ToVector3();
    }
}