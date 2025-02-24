using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float screenWidth = 8.5f;

    private Vector3 touchStartPos;
    private Vector3 paddleStartPos;

    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        // For mobile touch controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Record the start position of the touch
                touchStartPos = touch.position;
                paddleStartPos = transform.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the difference in touch movement
                float touchDelta = touch.position.x - touchStartPos.x;
                float newXPos = paddleStartPos.x + (touchDelta / Screen.width) * screenWidth;

                // Clamp the paddle position to the screen bounds
                newXPos = Mathf.Clamp(newXPos, -screenWidth, screenWidth);

                // Move the paddle
                transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
            }
        }
        else
        {
            // For desktop controls (if any), using keyboard or mouse
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 currentPosition = transform.position;
            currentPosition.x += horizontalInput * moveSpeed * Time.deltaTime;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -screenWidth, screenWidth);
            transform.position = currentPosition;
        }
        
#endif
    }
}
