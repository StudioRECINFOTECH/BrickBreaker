using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    public GameObject brickPrefab;
    private Level[] levels;
    private int currentLevelIndex = 0;

    void Start()
    {
        LoadLevelsFromJSON();
        LoadLevel(currentLevelIndex);
    }

    void LoadLevelsFromJSON()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("levels");
        if (jsonFile != null)
        {
            levels = JsonUtility.FromJson<LevelWrapper>(jsonFile.text).levels;
        }
    }

    public void LoadLevel(int index)
    {
        if (levels == null || index >= levels.Length) return;

        foreach (Vector2 pos in levels[index].brickPositions)
        {
            Instantiate(brickPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levels.Length)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("Game Completed!");
        }
    }
}

[System.Serializable]
public class LevelWrapper
{
    public Level[] levels;
}
