using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRB;
    private Animator birdAnimator;

    private bool isAlive = false;
    private Vector3 initialBirdPosition;
    private Quaternion initialBirdRotation;

    public float maxJumpVelocity = 5f;
    public float maxUpwardAngle = 45f;     
    public float maxDownwardAngle = -90f;  
    public float rotationLerpSpeed = 5f;
    public float gravityScale = 3f;
    
    private void Awake()
    {
    }

    void Start()
    {
        initialBirdPosition = transform.position;
        initialBirdRotation = transform.rotation;
        birdAnimator = GetComponent<Animator>();
        birdRB = GetComponent<Rigidbody2D>();
        birdRB.gravityScale = 0f; 
    }

    void Update()
    {
        if (isAlive)
        {
            if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
            {
                Jump();
            }
            RotateBasedOnVelocity();
        }
    }

    private void ResetJumpTrigger()
    {
        birdAnimator.ResetTrigger("Jump");
    }

    private void Jump()
    {
        birdRB.linearVelocity = Vector2.up * maxJumpVelocity;
        birdAnimator.SetTrigger("Jump");
    }

    void RotateBasedOnVelocity()
    {
        float verticalVelocity = birdRB.linearVelocity.y;

        float t = 0f;
        if (verticalVelocity > 0)
        {
            t = Mathf.InverseLerp(0, maxJumpVelocity, verticalVelocity);
        }
        else
        {
            t = Mathf.InverseLerp(0, -maxJumpVelocity, verticalVelocity);
            if (t < 0)
            {
                t = 0;
            }
        }
        float targetAngle = 0f;

        if(verticalVelocity > 0)
        {
            targetAngle = Mathf.Lerp(0, maxUpwardAngle, t);
        }
        else
        {
            targetAngle = Mathf.Lerp(0, maxDownwardAngle, t);
        }
        
        float currentZ = transform.eulerAngles.z;
        if (currentZ > 180)
        {
            currentZ -= 360;
        }

        float newZ = Mathf.Lerp(currentZ, targetAngle, Time.deltaTime * rotationLerpSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }

    public void StartGame()
    {
        isAlive = true;
        birdRB.gravityScale = gravityScale;
        birdRB.linearVelocity = Vector2.zero;
    }

    public void ResetBird()
    {
        isAlive = false;
        birdRB.gravityScale = 0f;
        transform.position = initialBirdPosition;
        transform.rotation = initialBirdRotation;
    }

    public void Die()
    {
        isAlive = false;
        birdRB.linearVelocity = Vector2.zero;
        GameManager.Instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
