using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float speedIncrease = 1.1f;
    
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float angle = Random.Range(20f, 40f);
        float angleRad = angle * Mathf.Deg2Rad;

        float xDir = Random.value < 0.5f ? 1 : -1;
        float yDir = Random.value < 0.5f ? 1 : -1;

        Vector2 direction = new Vector2(Mathf.Cos(angleRad) * xDir, Mathf.Sin(angleRad) * yDir).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            rb.linearVelocity *= speedIncrease;
        }
        else if (collision.gameObject.tag == "RightGoal")
        {
            gameManager.ScoreLeft();
            ResetBall();
        }
        else if (collision.gameObject.tag == "LeftGoal")
        {
            gameManager.ScoreRight();
            ResetBall();
        }
    }
}
