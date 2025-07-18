using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionX; 
    public float startPositionX; 

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= resetPositionX)
        {
            Vector2 newPos = new Vector2(startPositionX, transform.position.y);
            transform.position = newPos;
        }
    }
}
