using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "BrickBreaker/Level")]
public class LevelData : ScriptableObject
{
    public Vector2[] brickPositions;
}
