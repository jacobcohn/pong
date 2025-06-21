using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed = 5f;

    private readonly float trackUntilX = 4;

    void Update()
    {
        if (ball.position.x < trackUntilX)
        {
            float direction = ball.position.y - transform.position.y;
            float move = Mathf.Clamp(direction, -1f, 1f);
            transform.Translate(Vector2.up * move * speed * Time.deltaTime);
        }
    }
}