using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;  // Reference to the brick prefab
    public int rows = 5;            // Number of rows of bricks
    public int columns = 10;        // Number of columns of bricks
    public float horizontalSpacing = 1.1f;  // Spacing between bricks horizontally
    public float verticalSpacing = 0.8f;    // Spacing between bricks vertically
    public Vector2 startPos = new Vector2(-4.5f, 3.5f);  // Starting position for the first brick

    void Start()
    {
        // Loop to create a grid of bricks
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the position of each brick based on row and column
                Vector2 position = new Vector2(startPos.x + col * horizontalSpacing, startPos.y - row * verticalSpacing);

                // Instantiate the brick at the calculated position
                Instantiate(brickPrefab, position, Quaternion.identity);
            }
        }
    }
}
