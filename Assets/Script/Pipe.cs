using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -10f;
    private bool scored = false;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (!scored && transform.position.x < 0)
        {
            scored = true;
            GameManager.Instance.IncreaseScore();
        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
